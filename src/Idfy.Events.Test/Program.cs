using System;
using System.Threading.Tasks;
using Idfy.Events.Client;
using Idfy.Events.Entities;
using Newtonsoft.Json;
using Rebus.Config;
using Serilog;

namespace Idfy.Events.Test3
{
    class Program
    {
        private const string ClientId = "tb1133afb2a1140b383c27f70eede45b7";
        private const string ClientSecret = "NlXqhRB1ZKTc0RMqxl8rtyXDzs4+LpZX4DPjtH2ir6w=";
        
        static void Main(string[] args)
        {
            var client = EventClient.Setup(ClientId, ClientSecret)
                .LogToConsole()
                .AddRebusCompatibeLogger(x =>
                    x.Serilog(new LoggerConfiguration().WriteTo.ColoredConsole().MinimumLevel.Debug()))
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