using System;

namespace Idfy.Events.Entities
{
    public class SelfDeclarationAssignmentCreatedEvent : Event<SelfDeclarationAssignmentCreatedPayload>
    {
        public SelfDeclarationAssignmentCreatedEvent(SelfDeclarationAssignmentCreatedPayload payload, Guid accountId) :
            base(EventType.SelfDeclarationAssignmentCreated, payload, accountId)
        {
        }
    }
}