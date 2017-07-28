using System;
using System.Threading.Tasks;
using Idfy.Events.Client;
using Idfy.Events.Entities;
using Idfy.Events.Entities.Sign;
using Newtonsoft.Json;
using Rebus.Serilog;
using Serilog;

namespace Idfy.Events.Test
{
    class Program
    {
        static void Main(string[] args)
        {
          
            var client=EventClient

                .SetupWithPrimaryApiKey("",Guid.NewGuid(),"")
                
                .UseTestEnvironment(true)   
                .LogToConsole()  
                .AddRebusCompatibeLogger(x=>x.Serilog(new LoggerConfiguration().WriteTo.ColoredConsole().MinimumLevel.Debug()))
                .SubscribeToDocumentSignedEvent(DocumentSignedEvent)
                .SubscribeToDocumentCanceledEvent(DocumentCanceledEvent)
                .SubscribeToDocumentPartiallySignedEvent(DocumentPartiallySignedEvent)
                .Start();

            Console.ReadLine();
            client.Dispose();
        }
        
        private static async Task DocumentPartiallySignedEvent(DocumentPartiallySignedEvent arg)
        {
            System.IO.File.WriteAllText(string.Format("{0}_partial.json", arg.DocumentId), Newtonsoft.Json.JsonConvert.SerializeObject(arg, Formatting.Indented));
        }

        private static async  Task DocumentCanceledEvent(DocumentCanceledEvent arg)
        {
            System.IO.File.WriteAllText(string.Format("{0}_canceled.json", arg.DocumentId), Newtonsoft.Json.JsonConvert.SerializeObject(arg, Formatting.Indented));
        }

        private static Task DocumentSignedEvent(DocumentSignedEvent arg)
        {
            System.IO.File.WriteAllText(string.Format("{0}.json", arg.DocumentId), Newtonsoft.Json.JsonConvert.SerializeObject(arg, Formatting.Indented));
            return Task.FromResult(true);
        }
    }
}
