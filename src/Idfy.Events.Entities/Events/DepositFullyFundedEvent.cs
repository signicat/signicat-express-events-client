using System;

namespace Idfy.Events.Entities
{
    public class DepositFullyFundedEvent : Event<DepositFullyFundedEvent>
    {
        public DepositFullyFundedEvent(DepositFullyFundedEvent payload, Guid accountId) 
            : base(EventType.DepositFullyFunded, payload, accountId)
        {
        }
    }
}