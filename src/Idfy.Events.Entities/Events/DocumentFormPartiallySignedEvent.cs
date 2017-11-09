using System;

namespace Idfy.Events.Entities
{
    public class DocumentFormPartiallySignedEvent : Event<DocumentFormPartiallySignedPayload>
    {
        public DocumentFormPartiallySignedEvent(DocumentFormPartiallySignedPayload payload, Guid accountId) 
            : base(EventType.DocumentFormPartiallySigned, payload, accountId)
        {
        }
    }
}