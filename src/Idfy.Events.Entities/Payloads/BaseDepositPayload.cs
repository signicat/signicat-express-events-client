using System;

namespace Idfy.Events.Entities
{
    public class BaseDepositPayload
    {
        public Guid DepositId { get; set; }
        public string ExternalId { get; set; }
    }
}