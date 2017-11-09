using System;

namespace Idfy.Events.Entities
{
    public class DocumentEmailOpenedEvent : Event<DocumentEmailOpenedPayload>
    {
        public DocumentEmailOpenedEvent(DocumentEmailOpenedPayload payload, Guid accountId) 
            : base(EventType.DocumentEmailOpened, payload, accountId)
        {
        }
    }
}