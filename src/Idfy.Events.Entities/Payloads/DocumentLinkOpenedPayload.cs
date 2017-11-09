using System;

namespace Idfy.Events.Entities
{
    public class DocumentLinkOpenedPayload : BaseDocumentPayload
    {
        public Guid SignerId { get; set; }
        public string UserAgent { get; set; }
        public string IpAddress { get; set; }
    }
}