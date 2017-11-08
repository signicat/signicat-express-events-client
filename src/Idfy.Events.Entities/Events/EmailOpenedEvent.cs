using System;
using Idfy.Events.Entities.Payloads;

namespace Idfy.Events.Entities.Events
{
    public class EmailOpenedEvent : Event<EmailOpenedPayload>
    {
        public EmailOpenedEvent(EmailOpenedPayload payload, Guid accountId) 
            : base(EventType.EmailOpened, payload, accountId)
        {
        }
    }
}