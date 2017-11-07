using System;
using Idfy.Events.Entities.Payloads;

namespace Idfy.Events.Entities.Events
{
    public class DocumentPackagedEvent : Event<DocumentPackagedPayload>
    {
        public DocumentPackagedEvent(Guid accountId, DocumentPackagedPayload payload) 
            : base(EventType.DocumentPackaged, payload, accountId)
        {
        }
    }
}