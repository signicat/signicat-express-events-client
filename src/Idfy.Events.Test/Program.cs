using System;
using System.Threading.Tasks;
using Idfy.Events.Client;
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
                .SubscribeToDocumentCreatedEvent(DocumentCreatedEvent)
                .SubscribeToDocumentSignedEvent(DocumentSignedEvent)
                .SubscribeToDocumentCanceledEvent(DocumentCanceledEvent)
                .SubscribeToDocumentPartiallySignedEvent(DocumentPartiallySignedEvent)
                .Start();
            
            Console.ReadLine();
            client.Dispose();
        }

        private static Task DocumentCreatedEvent(DocumentCreatedEvent evt)
        {
            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(evt.Payload, Formatting.Indented));
            return Task.FromResult(0);
        }

        private static Task DocumentPartiallySignedEvent(DocumentPartiallySignedEvent evt)
        {
            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(evt.Payload, Formatting.Indented));
            return Task.FromResult(0);
        }

        private static  Task DocumentCanceledEvent(DocumentCanceledEvent evt)
        {
            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(evt.Payload, Formatting.Indented));
            return Task.FromResult(0);
        }

        private static Task DocumentSignedEvent(DocumentSignedEvent evt)
        {
            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(evt.Payload, Formatting.Indented));
            return Task.FromResult(0);
        }
    }
}
