using System;

namespace Idfy.Events.Entities
{
    public class ResourceCreatedEvent : Event<ResourceCreatedPayload>
    {
        public ResourceCreatedEvent(ResourceCreatedPayload payload, Guid accountId) 
            : base(EventType.ResourceCreated, payload, accountId)
        {
        }
    }
}