using System;
using Idfy.Events.Entities.Payloads;

namespace Idfy.Events.Entities.Events
{
    public class DocumentDeletedEvent : Event<DocumentDeletedPayload>
    {
        public DocumentDeletedEvent(Guid accountId, DocumentDeletedPayload payload) 
            : base(EventType.DocumentDeleted, payload, accountId)
        {
        }
    }
}