namespace Idfy.Events.Entities
{
    public class ShareRecipientsAuthenticatedPayload: BaseSharePayload
    {
        public string RecipientId { get; set; }
        public string RecipientExternalId { get; set; }
    }
}