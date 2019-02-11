namespace Idfy.Events.Entities
{
    public class ShareReceipientsAuthenticatedPayload: BaseSharePayload
    {
        public string RecipientId { get; set; }
        public string RecipientExternalId { get; set; }
    }
}