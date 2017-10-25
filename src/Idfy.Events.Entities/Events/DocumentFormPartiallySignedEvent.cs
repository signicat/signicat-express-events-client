using Idfy.Events.Entities.Payloads;

namespace Idfy.Events.Entities.Events
{
    public class DocumentFormPartiallySignedEvent : Event<DocumentFormPartiallySignedPayload>
    {
        public DocumentFormPartiallySignedEvent(DocumentFormPartiallySignedPayload payload) : base(
            EventType.DocumentFormPartiallySigned, payload)
        {
        }
    }
}