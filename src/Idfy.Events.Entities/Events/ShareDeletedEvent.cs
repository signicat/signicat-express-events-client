using System;

namespace Idfy.Events.Entities
{
    public class ShareDeletedEvent: Event<ShareDeletedPayload>
    {
        public ShareDeletedEvent(ShareDeletedPayload payload, Guid accountId) : base(EventType.ShareDeleted, payload, accountId)
        {
        }
    }
}