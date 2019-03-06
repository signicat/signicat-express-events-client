using System;

namespace Idfy.Events.Entities
{
    public class DepositFullyFundedEvent : Event<DepositFullyFundedPayload>
    {
        public DepositFullyFundedEvent(DepositFullyFundedPayload payload, Guid accountId) 
            : base(EventType.DepositFullyFunded, payload, accountId)
        {
        }
    }
}