using System;

namespace Idfy.Events.Entities
{
    public class ShareDownloadedEvent: Event<ShareDownloadedPayload>
    {
        public ShareDownloadedEvent(EventType type, ShareDownloadedPayload payload, Guid accountId) : base(type, payload, accountId)
        {
        }
    }
}