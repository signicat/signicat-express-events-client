using System;

namespace Idfy.Events.Entities
{
    public class EmailDeliveredEvent : Event<EmailDeliveredPayload>
    {
        public EmailDeliveredEvent(EmailDeliveredPayload payload, Guid accountId) 
            : base(EventType.EmailDelivered, payload, accountId)
        {
        }
    }
}