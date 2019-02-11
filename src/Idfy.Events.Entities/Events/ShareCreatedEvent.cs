using System;

namespace Idfy.Events.Entities
{
    public class ShareCreatedEvent: Event<ShareCreatedPayload>
    {
        public ShareCreatedEvent(EventType type, ShareCreatedPayload payload, Guid accountId) : base(type, payload, accountId)
        {
        }
    }
}