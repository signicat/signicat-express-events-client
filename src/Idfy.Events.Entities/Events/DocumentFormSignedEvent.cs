using System;

namespace Idfy.Events.Entities
{
    public class DocumentFormSignedEvent : Event<DocumentFormSignedPayload>
    {
        public DocumentFormSignedEvent(DocumentFormSignedPayload payload, Guid accountId) 
            : base(EventType.DocumentFormSigned, payload, accountId)
        {
        }
    }
}