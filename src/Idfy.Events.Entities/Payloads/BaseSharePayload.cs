using System;

namespace Idfy.Events.Entities
{
    public class BaseSharePayload
    {
        public Guid Id { get; set; }
        public string ExternalId { get; set; }
    }
}