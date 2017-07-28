using System;

namespace Idfy.Events.Entities.Sign
{
    public class DocumentCanceledEvent : BaseDocumentEvent
    {
        public string CanceledMessage { get; set; }
    }
}