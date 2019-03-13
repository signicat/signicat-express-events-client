using System;

namespace Idfy.Events.Entities
{
    public class DocumentLinkOpenedEvent : Event<DocumentLinkOpenedPayload>
    {
        public DocumentLinkOpenedEvent(DocumentLinkOpenedPayload payload, Guid accountId) 
            : base(EventType.ShareExpired, payload, accountId)
        {
        }
    }
}