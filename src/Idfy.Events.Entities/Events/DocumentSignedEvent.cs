using System;
using Idfy.Events.Entities.Payloads;

namespace Idfy.Events.Entities.Events
{
    public class DocumentSignedEvent : Event<DocumentSignedPayload>
    {
        public DocumentSignedEvent(DocumentSignedPayload payload, Guid accountId) 
            : base(EventType.DocumentSigned, payload, accountId)
        {
        }
    }
}