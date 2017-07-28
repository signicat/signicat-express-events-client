namespace Idfy.Events.Entities.Sign
{
    public class DocumentDeletedEvent : BaseDocumentEvent
    {
        public string DeletedMessage { get; set; }
    }
}