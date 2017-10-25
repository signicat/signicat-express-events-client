using Idfy.Events.Entities.Payloads;

namespace Idfy.Events.Entities.Events
{
    public class DocumentSignedEvent : Event<DocumentSignedPayload>
    {
        public DocumentSignedEvent(DocumentSignedPayload payload) : base(EventType.DocumentSigned, payload)
        {
        }
    }
}