using System;
using Idfy.Events.Entities.Payloads;

namespace Idfy.Events.Entities.Events
{
    public class DocumentFormSignedEvent : Event<DocumentFormSignedPayload>
    {
        public DocumentFormSignedEvent(Guid accountId, DocumentFormSignedPayload payload) 
            : base(EventType.DocumentFormSigned, payload, accountId)
        {
        }
    }
}