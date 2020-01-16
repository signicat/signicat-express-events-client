using System;

namespace Idfy.Events.Entities
{
    public class EmailOpenedEvent : Event<EmailOpenedEvent>
    {
        public EmailOpenedEvent(EmailOpenedEvent payload, Guid accountId) 
            : base(EventType.EmailOpened, payload, accountId)
        {
        }
    }
}