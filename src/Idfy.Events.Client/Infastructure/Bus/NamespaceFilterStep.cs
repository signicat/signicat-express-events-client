using System;
using System.Threading.Tasks;
using Rebus.Messages;
using Rebus.Pipeline;

namespace Idfy.Events.Client.Infastructure.Bus
{
    public class NamespaceFilterStep : IIncomingStep
    {
        private const string MessageTypeHeader = "rbs2-msg-type";
        
        public async Task Process(IncomingStepContext context, Func<Task> next)
        {
            var message = context.Load<TransportMessage>();
            var messageType = message.Headers.ContainsKey(MessageTypeHeader) ? message.Headers[MessageTypeHeader] : "";
            if (!messageType.StartsWith("Idfy.Events.Entities")) return;

            await next();
        }
    }
}