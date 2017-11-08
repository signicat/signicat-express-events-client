using System;
using Idfy.Events.Entities.Payloads;

namespace Idfy.Events.Entities.Events
{
    public class DocumentPackagedEvent : Event<DocumentPackagedPayload>
    {
        public DocumentPackagedEvent(DocumentPackagedPayload payload, Guid accountId) 
            : base(EventType.DocumentPackaged, payload, accountId)
        {
        }
    }
}