using System;

namespace Idfy.Events.Entities.Sign
{
    public class BaseDocumentEvent
    {
        public Guid DocumentId { get; set; }
        public string ExternalDocumentId { get; set; }
    }
}