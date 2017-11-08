using System;
using Idfy.Events.Entities.Payloads;

namespace Idfy.Events.Entities.Events
{
    public class DocumentFormSignedEvent : Event<DocumentFormSignedPayload>
    {
        public DocumentFormSignedEvent(DocumentFormSignedPayload payload, Guid accountId) 
            : base(EventType.DocumentFormSigned, payload, accountId)
        {
        }
    }
}