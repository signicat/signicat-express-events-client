using System;

namespace Idfy.Events.Entities
{
    public class SmsDeliveredEvent : Event<SmsDeliveredPayload>
    {
        public SmsDeliveredEvent(SmsDeliveredPayload payload, Guid accountId) 
            : base(EventType.SmsDelivered, payload, accountId)
        {
        }
    }
}