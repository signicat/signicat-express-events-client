using System;

namespace Idfy.Events.Entities
{
    public class DocumentDeletedEvent : Event<DocumentDeletedPayload>
    {
        public DocumentDeletedEvent(DocumentDeletedPayload payload, Guid accountId) 
            : base(EventType.DocumentDeleted, payload, accountId)
        {
        }
    }
}