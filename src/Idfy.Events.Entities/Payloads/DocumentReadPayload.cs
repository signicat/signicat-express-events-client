using System;

namespace Idfy.Events.Entities
{
    public class DocumentReadPayload : BaseDocumentPayload
    {
        public string UserAgent { get; set; }
        
        public string IpAddress { get; set; }
        
        public Signer Signer { get; set; }
    }
}