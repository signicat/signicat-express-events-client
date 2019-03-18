using System;

namespace Idfy.Events.Entities
{
    public class DepositBankAccountCreatedPayload : BaseDepositPayload
    {
        public Guid TenantId { get; set; }
    }
}