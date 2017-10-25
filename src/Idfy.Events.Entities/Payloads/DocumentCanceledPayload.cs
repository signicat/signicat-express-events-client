namespace Idfy.Events.Entities.Payloads
{
    public class DocumentCanceledPayload : BaseDocumentPayload
    {
        public string CanceledMessage { get; set; }
    }
}