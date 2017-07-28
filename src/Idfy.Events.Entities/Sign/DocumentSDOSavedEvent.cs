using System;

namespace Idfy.Events.Entities.Sign
{
    public class DocumentSDOSavedEvent : BaseDocumentEvent
    {
        public Guid? SchemaId { get; set; }

        public string Schema { get; set; }
    }
}