namespace Idfy.Events.Entities.Events
{
    public class DocumentCreatedEvent : Event<DocumentCreatedPayload>
    {
        public DocumentCreatedEvent(DocumentCreatedPayload payload) : base(EventType.DocumentCreated, payload)
        {
        }
    }
}