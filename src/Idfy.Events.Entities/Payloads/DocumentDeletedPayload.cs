namespace Idfy.Events.Entities.Payloads
{
    public class DocumentDeletedPayload : BaseDocumentPayload
    {
        public string DeletedMessage { get; set; }
    }
}