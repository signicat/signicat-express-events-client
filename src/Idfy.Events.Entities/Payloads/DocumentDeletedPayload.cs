namespace Idfy.Events.Entities
{
    public class DocumentDeletedPayload : BaseDocumentPayload
    {
        public string DeletedMessage { get; set; }
    }
}