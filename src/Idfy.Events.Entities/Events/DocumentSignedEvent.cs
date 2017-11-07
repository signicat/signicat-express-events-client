using System;
using Idfy.Events.Entities.Payloads;

namespace Idfy.Events.Entities.Events
{
    public class DocumentSignedEvent : Event<DocumentSignedPayload>
    {
        public DocumentSignedEvent(Guid accountId, DocumentSignedPayload payload) 
            : base(EventType.DocumentSigned, payload, accountId)
        {
        }
    }
}