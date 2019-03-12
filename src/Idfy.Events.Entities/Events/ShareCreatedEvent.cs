using System;

namespace Idfy.Events.Entities
{
    public class ShareCreatedEvent: Event<ShareCreatedPayload>
    {
        public ShareCreatedEvent(ShareCreatedPayload payload, Guid accountId) : base(EventType.ShareCreated, payload, accountId)
        {
        }
    }
}