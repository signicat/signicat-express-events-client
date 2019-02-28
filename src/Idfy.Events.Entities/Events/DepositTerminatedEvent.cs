using System;

namespace Idfy.Events.Entities
{
    public class DepositTerminatedEvent : Event<DepositTerminatedPayload>
    {
        public DepositTerminatedEvent(DepositTerminatedPayload payload, Guid accountId) 
            : base(EventType.DepositTerminated, payload, accountId)
        {
        }
    }
}