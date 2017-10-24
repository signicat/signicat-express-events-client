using System;

namespace Idfy.Events.Entities.Events
{
    public class BaseDocumentPayload
    {
        public Guid DocumentId { get; set; }
        public string ExternalDocumentId { get; set; }
    }
}