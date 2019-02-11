using System;

namespace Idfy.Events.Entities
{
    public class ShareReceipientDownloadedEvent: Event<ShareReceipientDownloadedPayload>
    {
        public ShareReceipientDownloadedEvent(EventType type, ShareReceipientDownloadedPayload payload, Guid accountId) : base(type, payload, accountId)
        {
        }
    }
}