using System;

namespace Idfy.Events.Entities
{
    public class DocumentExpiredEvent : Event<DocumentExpiredPayload>
    {
        public DocumentExpiredEvent(DocumentExpiredPayload payload, Guid accountId) 
            : base(EventType.DocumentExpired, payload, accountId)
        {
        }
    }
}