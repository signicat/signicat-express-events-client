using System;

namespace Idfy.Events.Entities
{
    public class DocumentPackagedPayload : BaseDocumentPayload
    {
        public string DownloadUrl { get; set; }
        
        public DateTime UrlExpiresAt { get; set; }
        
        public string Checksum { get; set; }
        
        public Guid? AttachmentId { get; set; }
    }
}