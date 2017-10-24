namespace Idfy.Events.Entities.Events
{
    public class DocumentDeletedPayload : BaseDocumentPayload
    {
        public string DeletedMessage { get; set; }
    }
}