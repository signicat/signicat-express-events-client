using System;
using Idfy.Events.Entities.Payloads;

namespace Idfy.Events.Entities.Events
{
    public class DocumentExpiredEvent : Event<DocumentExpiredPayload>
    {
        public DocumentExpiredEvent(Guid accountId, DocumentExpiredPayload payload) : 
            base(EventType.DocumentExpired, payload, accountId)
        {
        }
    }
}