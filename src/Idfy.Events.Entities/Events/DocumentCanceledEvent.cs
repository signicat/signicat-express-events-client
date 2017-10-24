namespace Idfy.Events.Entities.Events
{
    public class DocumentCanceledEvent : Event<DocumentCanceledPayload>
    {
        public DocumentCanceledEvent(DocumentCanceledPayload payload) : base(EventType.DocumentCanceled, payload)
        {
        }
    }
}