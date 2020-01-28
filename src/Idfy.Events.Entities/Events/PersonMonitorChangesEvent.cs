using System;

namespace Idfy.Events.Entities
{
    public class PersonMonitorChangesEvent : Event<PersonMonitorChangesPayload>
    {
        public PersonMonitorChangesEvent(PersonMonitorChangesPayload payload, Guid accountId) 
            : base(EventType.PersonMonitorChanges, payload, accountId)
        {
        }
    }
}