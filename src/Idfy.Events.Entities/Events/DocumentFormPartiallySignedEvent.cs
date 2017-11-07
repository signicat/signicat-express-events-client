using System;
using Idfy.Events.Entities.Payloads;

namespace Idfy.Events.Entities.Events
{
    public class DocumentFormPartiallySignedEvent : Event<DocumentFormPartiallySignedPayload>
    {
        public DocumentFormPartiallySignedEvent(Guid accountId, DocumentFormPartiallySignedPayload payload) 
            : base(EventType.DocumentFormPartiallySigned, payload, accountId)
        {
        }
    }
}