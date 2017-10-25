using System.Runtime.CompilerServices;
using Idfy.Events.Entities.Payloads;

namespace Idfy.Events.Entities.Events
{
    public class DocumentBeforeDeletedEvent : Event<DocumentBeforeDeletedPayload>
    {
        public DocumentBeforeDeletedEvent(DocumentBeforeDeletedPayload payload) : base(EventType.DocumentBeforeDeleted,
            payload)
        {
        }
    }
}