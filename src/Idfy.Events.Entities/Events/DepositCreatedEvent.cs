using System;

namespace Idfy.Events.Entities
{
    public class DepositCreatedEvent : Event<DepositCreatedPayload>
    {
        public DepositCreatedEvent(DepositCreatedPayload payload, Guid accountId) 
            : base(EventType.DepositCreated, payload, accountId)
        {
        }
    }
}