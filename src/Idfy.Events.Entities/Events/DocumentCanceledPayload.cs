using System;

namespace Idfy.Events.Entities.Events
{
    public class DocumentCanceledPayload : BaseDocumentPayload
    {
        public string CanceledMessage { get; set; }
    }
}