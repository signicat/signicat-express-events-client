using System;

namespace Idfy.Events.Entities
{
    public class DocumentSignedEvent : Event<DocumentSignedPayload>
    {
        public DocumentSignedEvent(DocumentSignedPayload payload, Guid accountId) 
            : base(EventType.DocumentSigned, payload, accountId)
        {
        }
    }
}