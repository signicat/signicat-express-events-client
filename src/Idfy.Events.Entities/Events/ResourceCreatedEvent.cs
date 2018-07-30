using System;

namespace Idfy.Events.Entities
{
    public class ResourceCreatedEvent : Event<ResourceCreatedPayload>
    {
        public ResourceCreatedEvent(EventType type, ResourceCreatedPayload payload, Guid accountId) 
            : base(EventType.ResourceCreated, payload, accountId)
        {
        }
    }
}