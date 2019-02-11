using System;

namespace Idfy.Events.Entities
{
    public class ShareDeletedEvent: Event<ShareDeletedPayload>
    {
        public ShareDeletedEvent(EventType type, ShareDeletedPayload payload, Guid accountId) : base(type, payload, accountId)
        {
        }
    }
}