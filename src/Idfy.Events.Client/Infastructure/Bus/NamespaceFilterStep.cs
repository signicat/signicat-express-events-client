using System;
using System.Threading.Tasks;
using Rebus.Messages;
using Rebus.Pipeline;

namespace Idfy.Events.Client.Infastructure.Bus
{
    public class NamespaceFilterStep : IIncomingStep
    {
        public async Task Process(IncomingStepContext context, Func<Task> next)
        {
            var message = context.Load<TransportMessage>();
            var messageType = message.Headers.ContainsKey(Rebus.Messages.Headers.Type) ? message.Headers[Rebus.Messages.Headers.Type] : "";
            if (!messageType.StartsWith("Idfy.Events.Entities")) return;

            await next();
        }
    }
}