using System;

namespace Idfy.Events.Entities
{
    public class DocumentPartiallySignedEvent : Event<DocumentPartiallySignedPayload>
    {
        public DocumentPartiallySignedEvent(DocumentPartiallySignedPayload payload, Guid accountId) 
            : base(EventType.DocumentPartiallySigned, payload, accountId)
        {
        }
    }
}