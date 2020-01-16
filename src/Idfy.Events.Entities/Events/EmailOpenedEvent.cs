using System;

namespace Idfy.Events.Entities
{
    public class EmailOpenedEvent : Event<EmailOpenedPayload>
    {
        public EmailOpenedEvent(EmailOpenedPayload payload, Guid accountId) 
            : base(EventType.EmailOpened, payload, accountId)
        {
        }
    }
}