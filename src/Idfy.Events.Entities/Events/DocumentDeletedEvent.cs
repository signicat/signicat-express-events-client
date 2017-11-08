using System;
using Idfy.Events.Entities.Payloads;

namespace Idfy.Events.Entities.Events
{
    public class DocumentDeletedEvent : Event<DocumentDeletedPayload>
    {
        public DocumentDeletedEvent(DocumentDeletedPayload payload, Guid accountId) 
            : base(EventType.DocumentDeleted, payload, accountId)
        {
        }
    }
}