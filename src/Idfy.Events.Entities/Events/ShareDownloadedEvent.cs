using System;

namespace Idfy.Events.Entities
{
    public class ShareDownloadedEvent: Event<ShareDownloadedPayload>
    {
        public ShareDownloadedEvent(ShareDownloadedPayload payload, Guid accountId) : base(EventType.ShareDownloaded, payload, accountId)
        {
        }
    }
}