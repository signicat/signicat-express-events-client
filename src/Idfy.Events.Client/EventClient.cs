using System;
using System.Collections.Specialized;
using System.Threading.Tasks;
using Idfy.Events.Client.Infastructure;
using Idfy.Events.Client.Infastructure.Bus;
using Idfy.Events.Entities;
using Rebus.Activation;
using Rebus.Bus;
using Rebus.Compression;
using Rebus.Config;
using Rebus.Encryption;
using Rebus.Logging;

namespace Idfy.Events.Client
{
    /// <summary>
    /// Event client that lets you subscribe to events that occurs on your account. 
    /// Remember to dispose of the client when your program exits by calling the Dispose() method.
    /// </summary>
    public class EventClient : IDisposable
    {
        private IBus _bus;
        private Action<RebusLoggingConfigurer> _rebusLoggingConfigurer;
        private bool _noRebusLogger;
        
        private readonly BuiltinHandlerActivator _adapter;
        private readonly IdfyEnvironment _environment;
        private readonly Guid _accountId;
        private readonly string _clientId;
        private readonly string _clientSecret;
        private readonly string _scope;

        /// <summary>
        /// Sets up the event client to subscribe to events that occurs on the provided account.
        /// </summary>
        /// <param name="accountId">Your Idfy account ID</param>
        /// <param name="oauthClientId">Your OAuth client ID</param>
        /// <param name="oauthClientSecret">Your OAuth client secret</param>
        /// <param name="environment">The environment to use</param>
        /// <returns><see cref="EventClient"/></returns>
        public static EventClient Setup(Guid accountId, string oauthClientId, string oauthClientSecret, IdfyEnvironment environment = IdfyEnvironment.Production)
        {
            if (accountId == Guid.Empty)
                throw new ArgumentNullException(nameof(accountId));
            
            if (string.IsNullOrWhiteSpace(oauthClientId))
                throw new ArgumentNullException(nameof(oauthClientId));
            
            if (string.IsNullOrWhiteSpace(oauthClientSecret))
                throw new ArgumentNullException(nameof(oauthClientSecret));
            
            var adapter = new BuiltinHandlerActivator();
            return new EventClient(adapter, accountId, oauthClientId, oauthClientSecret, environment);
        }
        
        /// <summary>
        /// Disposes the Event Client, which also disposes the bus. You should always call this method when your program has completed.
        /// </summary>
        public void Dispose()
        {
            _bus?.Dispose();
        }

        internal bool LogToConsole { get; set; }
        
        internal LogLevel? LogLevel { get; set; }
        
        internal IRebusLoggerFactory RebusLoggerFactory { get; set; }
        
        internal RebusLoggingConfigurer Configurer { get; set; }

        internal void Subscribe<T>(Func<T, Task> func) where T : Event
        {
            _adapter.Handle(func);
        }

        internal void SubscribeToAllEvents(Func<Event, Task> func)
        {
            _adapter.Handle(func);
        }

        internal void Start()
        {
            _bus = ConfigureRebus().Start();
        }

        internal void AddRebusCompatibeLogger(Action<RebusLoggingConfigurer> config)
        {
            _rebusLoggingConfigurer = config;
            _noRebusLogger = config == null;
        }
        
        private EventClient(BuiltinHandlerActivator adapter, Guid accountId, string clientId, string clientSecret, IdfyEnvironment environment)
        {
            _adapter = adapter;
            _noRebusLogger = true;
            _environment = environment;
            _accountId = accountId;
            _clientId = clientId;
            _clientSecret = clientSecret;
            _scope = "root";
        }

        private RebusConfigurer ConfigureRebus()
        {
            var config = GetEventClientConfiguration();
            var queueName = _accountId.ToString("n");

            return Configure.With(_adapter)
                .Transport(x => x.UseAzureServiceBus(config.ConnectionString, queueName, AzureServiceBusMode.Basic)
                    .DoNotCreateQueues())
                .Options(c =>
                {
                    c.AddNamespaceFilter();
                    c.EnableCompression();
                    c.EnableEncryption(config.EncryptionKey);
                })
                .Logging(x =>
                {
                    if (LogToConsole)
                        x.ColoredConsole(LogLevel ?? Rebus.Logging.LogLevel.Error);
                    else if (RebusLoggerFactory != null)
                    {
                        x.Use(RebusLoggerFactory);
                    }
                    else if (_rebusLoggingConfigurer != null)
                    {
                        _rebusLoggingConfigurer(x);
                    }
                    else if (_noRebusLogger)
                    {
                        x.None();
                    }
                });
        }

        private EventClientConfiguration GetEventClientConfiguration()
        {
            // Get access token
            var tokenEndpoint = _environment == IdfyEnvironment.Test ? Urls.OauthTest : Urls.OauthProd;
            var queryParams = new NameValueCollection()
            {
                {"grant_type", "client_credentials"},
                {"scope", _scope},
                {"client_id", _clientId},
                {"client_secret", _clientSecret}
            }.ToQueryString();
            
            var tokenUrl = $@"{tokenEndpoint}{queryParams}";
            
            var tokenResponse = Mapper<TokenResponse>.MapFromJson(Requestor.PostString(tokenUrl));
            
            // Get event configuration
            var eventEndpoint = _environment == IdfyEnvironment.Test ? Urls.EventsApiTest : Urls.EventsApiProd;
            var eventConfigUrl = $"{eventEndpoint}/client/{_accountId}";

            var eventConfigResponse = Mapper<EventClientConfiguration>.MapFromJson(Requestor.GetString(eventConfigUrl, tokenResponse.AccessToken));

            if (string.IsNullOrWhiteSpace(eventConfigResponse.ConnectionString))
            {
                // first-time setup of client is required
                eventConfigResponse = Mapper<EventClientConfiguration>.MapFromJson(Requestor.PostString($"{eventConfigUrl}/setup"));
            }

            return eventConfigResponse;
        }
    }
}
