using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Idfy.Events.Client.Oauth;
using Idfy.Events.Entities.Events;
using Rebus.Activation;
using Rebus.Bus;
using Rebus.Compression;
using Rebus.Config;
using Rebus.Encryption;
using Rebus.Logging;

namespace Idfy.Events.Client
{
    /// <summary>
    /// Event client for Idfy. Remember to dispose of the client when done by calling the Dispose() method.
    /// </summary>
    public class EventClient : IDisposable
    {
        public IOauthClient OauthClient;
        public string SignatureApiUrl;
        public string EventsApiUrl;

        private readonly string _connectionstring;
        private readonly Guid _accountId;
        private readonly string _queuename;
        private readonly BuiltinHandlerActivator adapter;
        public IBus Bus;
        private Func<DocumentCanceledEvent, Task> DocumentCanceledEventFunc;
        private Func<DocumentPartiallySignedEvent, Task> DocumentPartialSignedEventFunc;
        private Func<DocumentSignedEvent, Task> DocumentSignedEventFunc;
        private Action<RebusLoggingConfigurer> rebusLoggingConfigurer;

        internal EventClient(BuiltinHandlerActivator adapter, string connectionstring, Guid accountId,
            string oauthClientId, string oauthClientSecret, bool testEnvironment)
        {
            this.adapter = adapter;
            _connectionstring = connectionstring;
            _accountId = accountId;
            _queuename = _accountId.ToString("n");
            NoRebusLogger = true;
            var tokenEndpoint = testEnvironment ? OauthTokenEndpoint.SignereTest : OauthTokenEndpoint.SignereProd;
            SignatureApiUrl = testEnvironment ? Urls.SignatureApiTest : Urls.SignatureApiProd;

            if (SignatureApiUrl.Last().Equals('/'))
                SignatureApiUrl = SignatureApiUrl.Remove(SignatureApiUrl.Length - 1);

            EventsApiUrl = testEnvironment ? Urls.EventsApiTest : Urls.EventsApiProd;
            if (EventsApiUrl.Last().Equals('/'))
                EventsApiUrl = EventsApiUrl.Remove(EventsApiUrl.Length - 1);

            OauthClient = new OauthClient(oauthClientId, oauthClientSecret, tokenEndpoint);
        }

        internal string APIURL { get; set; }

        internal bool LogToConsole { get; set; }
        internal Rebus.Logging.LogLevel? logLevel { get; set; }


        internal void SubscribeToDocumentSignedEvent(Func<DocumentSignedEvent, Task> func)
        {
            adapter.Handle(func);
        }

        internal void SubscribeToDocumentCanceledEvent(Func<DocumentCanceledEvent, Task> func)
        {
            adapter.Handle(func);
        }

        internal void SubscribeToDocumentPartiallySignedEvent(Func<DocumentPartiallySignedEvent, Task> func)
        {
            adapter.Handle(func);
        }

        internal void SubscribeToDocumentFormSignedEvent(Func<DocumentFormSignedEvent, Task> func)
        {
            adapter.Handle(func);
        }

        internal void SubscribeToDocumentFormPartiallySignedEvent(Func<DocumentFormPartiallySignedEvent, Task> func)
        {
            adapter.Handle(func);
        }

        internal void SubscribeToDocumentCreatedEvent(Func<DocumentCreatedEvent, Task> func)
        {
            adapter.Handle(func);
        }

        internal void SubscribeToDocumentExpiredEvent(Func<DocumentExpiredEvent, Task> func)
        {
            adapter.Handle(func);
        }

        internal void SubscribeToDocumentBeforeDeletedEvent(Func<DocumentBeforeDeletedEvent, Task> func)
        {
            adapter.Handle(func);
        }

        internal void SubscribeToDocumentDeletedEvent(Func<DocumentDeletedEvent, Task> func)
        {
            adapter.Handle(func);
        }

        /// <summary>
        /// Sets up the EventClient to download events from the ServiceBus and files from the signature API.
        /// </summary>
        /// <param name="azureServiceBusConnectionString">Your ServiceBus connection string. Contact support@idfy.io to get this</param>
        /// <param name="accountId">Your account ID</param>
        /// <param name="oauthClientId">Your oauth client Id</param>
        /// <param name="oauthClientSecret">Your oauth client secret</param>
        /// <param name="testEnvironment">Set to true if production environment</param>
        /// <returns>EventClient set up using the secondary API key</returns>
        public static EventClient SetupClient(string azureServiceBusConnectionString, Guid accountId,
            string oauthClientId, string oauthClientSecret, bool testEnvironment)
        {
            var adapter = new BuiltinHandlerActivator();

            return new EventClient(adapter, azureServiceBusConnectionString, accountId, oauthClientId,
                oauthClientSecret, testEnvironment);
        }

        internal void Start()
        {
            Bus = ConfigureRebus().Start();
        }

        internal void AddRebusCompatibeLogger(Action<RebusLoggingConfigurer> config)
        {
            rebusLoggingConfigurer = config;
            if (config != null)
            {
                this.NoRebusLogger = false;
            }
            else
            {
                this.NoRebusLogger = true;
            }
        }

        public bool NoRebusLogger { get; set; }

        private RebusConfigurer ConfigureRebus()
        {
            string encryptionKey = DownloadEncryptionKey();
            return Configure.With(adapter)
                .Transport(x => x.UseAzureServiceBus(_connectionstring, _queuename, AzureServiceBusMode.Basic)
                    .DoNotCreateQueues())
                .Options(c =>
                {
                    c.EnableCompression();
                    c.EnableEncryption(encryptionKey);
                })
                .Logging(x =>
                {
                    if (LogToConsole)
                        x.ColoredConsole(this.logLevel == null ? Rebus.Logging.LogLevel.Error : this.logLevel.Value);
                    else if (RebusLoggerFactory != null)
                    {
                        x.Use(RebusLoggerFactory);
                    }
                    else if (rebusLoggingConfigurer != null)
                    {
                        rebusLoggingConfigurer(x);
                    }
                    else if (NoRebusLogger)
                    {
                        x.None();
                    }
                });
        }

        internal IRebusLoggerFactory RebusLoggerFactory { get; set; }

        internal RebusLoggingConfigurer Configurer { get; set; }

        #region Download files

        private async Task<byte[]> DownloadDocument(Guid documentId, FileFormat fileFormat)
        {
            var url = $"{SignatureApiUrl}/api/external/documentfile/{_accountId}?fileFormat={fileFormat.ToString()}";

            return await DownloadFile(url, OauthClient.GetAccessToken("root"));
        }


        private string DownloadEncryptionKey()
        {
            var url = $"{EventsApiUrl}/api/events/{_accountId}";

            var resultBytes = Extensions.RunSync(() => DownloadFile(url, OauthClient.GetAccessToken("root")));
            var result = Encoding.UTF8.GetString(resultBytes);

            //Hack to unescape string
            result = result.Substring(1, result.Length - 2);
            return result;
        }

        private async Task<byte[]> DownloadFile(string url, string token)
        {
            using (var client = new HttpClient())
            {
                try
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    return await client.GetByteArrayAsync(url);
                }
                catch (Exception e)
                {
                    if (LogToConsole)
                        Console.WriteLine(e);

                    throw;
                }
            }
            return null;
        }

        #endregion

        /// <summary>
        /// Disposes the Event Client, which also disposes the bus. You should always call this method when your program has completed.
        /// </summary>
        public void Dispose()
        {
            Bus?.Dispose();
        }
    }
}