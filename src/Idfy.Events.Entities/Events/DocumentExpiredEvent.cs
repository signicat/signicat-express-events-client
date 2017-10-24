namespace Idfy.Events.Entities.Events
{
    public class DocumentExpiredEvent : Event<DocumentExpiredPayload>
    {
        public DocumentExpiredEvent(DocumentExpiredPayload payload) : base(EventType.DocumentExpired, payload)
        {
        }
    }
}