using System;

namespace Idfy.Events.Entities
{
    public class DocumentReadEvent : Event<DocumentReadPayload>
    {
        public DocumentReadEvent(DocumentReadPayload payload, Guid accountId) 
            : base(EventType.DocumentRead, payload, accountId)
        {
        }
    }
}