using System;

namespace Idfy.Events.Entities
{
    public class ShareReceipientsAuthenticatedEvent:Event<ShareReceipientsAuthenticatedPayload>
    {
        public ShareReceipientsAuthenticatedEvent(EventType type, ShareReceipientsAuthenticatedPayload payload, Guid accountId) : base(type, payload, accountId)
        {
        }
    }
}