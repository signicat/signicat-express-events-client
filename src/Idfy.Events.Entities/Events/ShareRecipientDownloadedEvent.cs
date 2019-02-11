using System;

namespace Idfy.Events.Entities
{
    public class ShareRecipientDownloadedEvent: Event<ShareRecipientDownloadedPayload>
    {
        public ShareRecipientDownloadedEvent(EventType type, ShareRecipientDownloadedPayload payload, Guid accountId) : base(type, payload, accountId)
        {
        }
    }
}