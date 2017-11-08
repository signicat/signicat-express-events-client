using System;
using Idfy.Events.Entities.Payloads;

namespace Idfy.Events.Entities.Events
{
    public class DocumentExpiredEvent : Event<DocumentExpiredPayload>
    {
        public DocumentExpiredEvent(DocumentExpiredPayload payload, Guid accountId) 
            : base(EventType.DocumentExpired, payload, accountId)
        {
        }
    }
}