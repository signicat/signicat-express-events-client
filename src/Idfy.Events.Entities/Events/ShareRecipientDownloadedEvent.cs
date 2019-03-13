using System;

namespace Idfy.Events.Entities
{
    public class ShareRecipientDownloadedEvent: Event<ShareRecipientDownloadedPayload>
    {
        public ShareRecipientDownloadedEvent(ShareRecipientDownloadedPayload payload, Guid accountId) : base(EventType.ShareRecipientDownloaded, payload, accountId)
        {
        }
    }
}