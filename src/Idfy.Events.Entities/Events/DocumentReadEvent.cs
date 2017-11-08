using System;
using Idfy.Events.Entities.Payloads;

namespace Idfy.Events.Entities.Events
{
    public class DocumentReadEvent : Event<DocumentReadPayload>
    {
        public DocumentReadEvent(DocumentReadPayload payload, Guid accountId) 
            : base(EventType.DocumentRead, payload, accountId)
        {
        }
    }
}