using System;
using Idfy.Events.Entities.Payloads;

namespace Idfy.Events.Entities.Events
{
    public class DocumentCreatedEvent : Event<DocumentCreatedPayload>
    {
        public DocumentCreatedEvent(Guid accountId, DocumentCreatedPayload payload) 
            : base(EventType.DocumentCreated, payload, accountId)
        {
        }
    }
}