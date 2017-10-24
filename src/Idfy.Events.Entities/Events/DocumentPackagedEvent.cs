namespace Idfy.Events.Entities.Events
{
    public class DocumentPackagedEvent : Event<DocumentPackagedPayload>
    {
        public DocumentPackagedEvent(DocumentPackagedPayload payload) : base(EventType.DocumentPackaged, payload)
        {
        }
    }
}