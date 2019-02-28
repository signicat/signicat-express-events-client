using System;

namespace Idfy.Events.Entities
{
    public class DepositPartiallyFundedEvent : Event<DepositPartiallyFundedPayload>
    {
        public DepositPartiallyFundedEvent(DepositPartiallyFundedPayload payload, Guid accountId) 
            : base(EventType.DepositPartiallyFunded, payload, accountId)
        {
        }
    }
}