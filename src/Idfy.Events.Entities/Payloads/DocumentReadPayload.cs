using System;

namespace Idfy.Events.Entities
{
    public class DocumentReadPayload : BaseDocumentPayload
    {
        public Guid SignerId { get; set; }
        public string UserAgent { get; set; }
        public string IpAddress { get; set; }
    }
}