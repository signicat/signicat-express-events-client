using System;

namespace Idfy.Events.Entities
{
    public class DocumentCreatedEvent : Event<DocumentCreatedPayload>
    {
        public DocumentCreatedEvent(DocumentCreatedPayload payload, Guid accountId) 
            : base(EventType.DocumentCreated, payload, accountId)
        {
        }
    }
}