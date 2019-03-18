using System;

namespace Idfy.Events.Entities
{
    public class DepositBankAccountCreatedEvent : Event<DepositBankAccountCreatedPayload>
    {
        public DepositBankAccountCreatedEvent(DepositBankAccountCreatedPayload payload, Guid accountId) : base(EventType.DepositBankAccountCreated, payload, accountId)
        {
        }
    }
}