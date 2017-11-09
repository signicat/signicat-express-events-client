using System;

namespace Idfy.Events.Entities
{
    public class DocumentCanceledEvent : Event<DocumentCanceledPayload>
    {
        public DocumentCanceledEvent(DocumentCanceledPayload payload, Guid accountId) 
            : base(EventType.DocumentCanceled, payload, accountId)
        {
        }
    }
}