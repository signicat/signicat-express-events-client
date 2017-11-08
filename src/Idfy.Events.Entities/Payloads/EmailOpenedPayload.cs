using System;

namespace Idfy.Events.Entities.Payloads
{
    public class EmailOpenedPayload
    {
        public Guid DocumentId { get; set; }
        public Guid SignerId { get; set; }
        public string Email { get; set; }
    }
}