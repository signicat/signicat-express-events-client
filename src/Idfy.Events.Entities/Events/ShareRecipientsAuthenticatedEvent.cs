using System;

namespace Idfy.Events.Entities
{
    public class ShareRecipientsAuthenticatedEvent:Event<ShareRecipientsAuthenticatedPayload>
    {
        public ShareRecipientsAuthenticatedEvent(EventType type, ShareRecipientsAuthenticatedPayload payload, Guid accountId) : base(type, payload, accountId)
        {
        }
    }
}