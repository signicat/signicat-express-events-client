using System;

namespace Idfy.Events.Entities.Sign
{
    public class DocumentPadesSavedEvent : BaseDocumentEvent
    { 
        public Guid? SchemaId { get; set; }
        public string Schema { get; set; }
    }
}