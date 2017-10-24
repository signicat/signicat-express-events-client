namespace Idfy.Events.Entities.Events
{
    public class DocumentDeletedEvent : Event<DocumentDeletedPayload>
    {
        public DocumentDeletedEvent(DocumentDeletedPayload payload) : base(EventType.DocumentDeleted, payload)
        {
        }
    }
}