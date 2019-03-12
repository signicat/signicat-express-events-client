using System;

namespace Idfy.Events.Entities
{
    public class ShareExpiredEvent: Event<ShareExpiredPayload>
    {
        public ShareExpiredEvent(ShareExpiredPayload payload, Guid accountId) : base(EventType.ShareExpired, payload, accountId)
        {
        }
    }
}