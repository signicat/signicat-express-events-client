using System;

namespace Idfy.Events.Entities
{
    public class DocumentPackagedEvent : Event<DocumentPackagedPayload>
    {
        public DocumentPackagedEvent(DocumentPackagedPayload payload, Guid accountId) 
            : base(EventType.DocumentPackaged, payload, accountId)
        {
        }
    }
}