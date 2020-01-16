using System;

namespace Idfy.Events.Entities
{
    public class BaseMessagePayload
    {
        public Guid MessageId { get; set; }
        public string Status { get; set; }
    }
}