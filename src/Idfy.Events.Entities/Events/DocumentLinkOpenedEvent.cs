using System;
using Idfy.Events.Entities.Payloads;

namespace Idfy.Events.Entities.Events
{
    public class DocumentLinkOpenedEvent : Event<DocumentLinkOpenedPayload>
    {
        public DocumentLinkOpenedEvent(DocumentLinkOpenedPayload payload, Guid accountId) 
            : base(EventType.DocumentLinkOpened, payload, accountId)
        {
        }
    }
}