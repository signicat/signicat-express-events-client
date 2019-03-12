using System;

namespace Idfy.Events.Entities
{
    public class ShareRecipientsAuthenticatedEvent:Event<ShareRecipientsAuthenticatedPayload>
    {
        public ShareRecipientsAuthenticatedEvent(ShareRecipientsAuthenticatedPayload payload, Guid accountId) : base(EventType.ShareRecipientsAuthenticated, payload, accountId)
        {
        }
    }
}