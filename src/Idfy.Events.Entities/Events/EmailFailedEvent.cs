using System;

namespace Idfy.Events.Entities
{
    public class EmailFailedEvent : Event<EmailFailedPayload>
    {
        public EmailFailedEvent(EmailFailedPayload payload, Guid accountId) 
            : base(EventType.EmailFailed, payload, accountId)
        {
        }
    }
}