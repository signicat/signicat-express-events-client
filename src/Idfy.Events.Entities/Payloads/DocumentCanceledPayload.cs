namespace Idfy.Events.Entities
{
    public class DocumentCanceledPayload : BaseDocumentPayload
    {
        public string CanceledMessage { get; set; }
    }
}