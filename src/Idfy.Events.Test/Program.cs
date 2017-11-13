using System;
using System.Threading.Tasks;
using Idfy.Events.Client;
using Idfy.Events.Client.Infastructure;
using Idfy.Events.Entities;
using Newtonsoft.Json;
using Rebus.Config;
using Serilog;

namespace Idfy.Events.Test
{
    class Program
    {
        private const string AccountId = "";
        private const string ClientId = "";
        private const string ClientSecret = "";
        
        static void Main(string[] args)
        {
            var client = EventClient.Setup(new Guid(AccountId), ClientId, ClientSecret, IdfyEnvironment.Test)                
                .LogToConsole()  
                .AddRebusCompatibeLogger(x=>x.Serilog(new LoggerConfiguration().WriteTo.ColoredConsole().MinimumLevel.Debug()))
                .SubscribeToAllEvents(EventHandler)
                .Subscribe<DocumentCreatedEvent>(DocumentCreatedEventHandler)
                .Subscribe<DocumentSignedEvent>(DocumentSignedEventHandler)
                .Start();
            
            Console.ReadLine();
            client?.Dispose();
        }

        private static Task EventHandler(Event evt)
        {
            Console.WriteLine(JsonConvert.SerializeObject(evt, Formatting.Indented));
            
            if (evt.Type == EventType.DocumentCreated)
            {
                var payload = evt.RawPayload as DocumentCreatedPayload;
                Console.WriteLine($"A new document with ID {payload?.DocumentId} was created.");
            }
            
            return Task.FromResult(0);
        }

        private static Task DocumentCreatedEventHandler(DocumentCreatedEvent evt)
        {
            Console.WriteLine(JsonConvert.SerializeObject(evt.Payload, Formatting.Indented));
            return Task.FromResult(0);
        }

        private static Task DocumentSignedEventHandler(DocumentSignedEvent evt)
        {
            Console.WriteLine(JsonConvert.SerializeObject(evt.Payload, Formatting.Indented));
            return Task.FromResult(0);
        }
    }
}
