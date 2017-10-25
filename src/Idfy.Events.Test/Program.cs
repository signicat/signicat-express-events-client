﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Idfy.Events.Client;
using Idfy.Events.Entities;
using Idfy.Events.Entities.Events;
using Idfy.Events.Entities.Payloads;
using Newtonsoft.Json;
using Rebus.Config;
using Serilog;

namespace Idfy.Events.Test
{
    class Program
    {
        static void Main(string[] args)
        {
          
            var client=EventClient

                .SetupClient(azureServiceBusConnectionString: "Enter your event (servicebus) connection string", accountId:Guid.Parse("Enter account ID"), 
                oauthClientId: "Enter oauth client ID", oauthClientSecret: "Enter oauth secret", testEnvironment: true)
                
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

        private static Task DocumentCreatedEvent(DocumentCreatedPayload payload)
        {
            System.IO.File.WriteAllText($"{payload.DocumentId}_created.json", Newtonsoft.Json.JsonConvert.SerializeObject(payload, Formatting.Indented));
            return Task.FromResult(0);
        }

        private static Task DocumentPartiallySignedEvent(DocumentPartiallySignedPayload payload)
        {
            System.IO.File.WriteAllText($"{payload.DocumentId}_partial.json", Newtonsoft.Json.JsonConvert.SerializeObject(payload, Formatting.Indented));
            return Task.FromResult(0);
        }

        private static  Task DocumentCanceledEvent(DocumentCanceledPayload payload)
        {
            System.IO.File.WriteAllText($"{payload.DocumentId}_canceled.json", Newtonsoft.Json.JsonConvert.SerializeObject(payload, Formatting.Indented));
            return Task.FromResult(0);
        }

        private static Task DocumentSignedEvent(DocumentSignedPayload payload)
        {
            System.IO.File.WriteAllText($"{payload.DocumentId}_signed.json", Newtonsoft.Json.JsonConvert.SerializeObject(payload, Formatting.Indented));
            return Task.FromResult(0);
        }
    }
}
