using System;

namespace Idfy.Events.Entities
{
    public class SmsFailedEvent : Event<SmsFailedPayload>
    {
        public SmsFailedEvent(SmsFailedPayload payload, Guid accountId) 
            : base(EventType.SmsFailed, payload, accountId)
        {
        }
    }
}