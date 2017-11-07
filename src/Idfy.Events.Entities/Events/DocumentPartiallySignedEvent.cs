using System;
using Idfy.Events.Entities.Payloads;

namespace Idfy.Events.Entities.Events
{
    public class DocumentPartiallySignedEvent : Event<DocumentPartiallySignedPayload>
    {
        public DocumentPartiallySignedEvent(Guid accountId, DocumentPartiallySignedPayload payload) 
            : base(EventType.DocumentPartiallySigned, payload, accountId)
        {
        }
    }
}