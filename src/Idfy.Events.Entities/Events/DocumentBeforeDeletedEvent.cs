using System;

namespace Idfy.Events.Entities
{
    public class DocumentBeforeDeletedEvent : Event<DocumentBeforeDeletedPayload>
    {
        public DocumentBeforeDeletedEvent(DocumentBeforeDeletedPayload payload, Guid accountId) 
            : base(EventType.DocumentBeforeDeleted, payload, accountId)
        {
        }
    }
}