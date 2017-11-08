using System;
using Idfy.Events.Entities.Payloads;

namespace Idfy.Events.Entities.Events
{
    public class DocumentCreatedEvent : Event<DocumentCreatedPayload>
    {
        public DocumentCreatedEvent(DocumentCreatedPayload payload, Guid accountId) 
            : base(EventType.DocumentCreated, payload, accountId)
        {
        }
    }
}