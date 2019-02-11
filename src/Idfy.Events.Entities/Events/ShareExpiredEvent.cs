using System;

namespace Idfy.Events.Entities
{
    public class ShareExpiredEvent: Event<ShareExpiredPayload>
    {
        public ShareExpiredEvent(EventType type, ShareExpiredPayload payload, Guid accountId) : base(type, payload, accountId)
        {
        }
    }
}