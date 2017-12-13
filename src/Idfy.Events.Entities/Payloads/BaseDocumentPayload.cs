using System;

namespace Idfy.Events.Entities
{
    public class BaseDocumentPayload
    {
        public Guid DocumentId { get; set; }
        
        public string ExternalDocumentId { get; set; }
    }
}