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