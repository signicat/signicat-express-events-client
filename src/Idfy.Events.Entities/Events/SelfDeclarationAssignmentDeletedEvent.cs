using System;

namespace Idfy.Events.Entities
{
    public class SelfDeclarationAssignmentDeletedEvent : Event<SelfDeclarationAssignmentDeletedPayload>
    {
        public SelfDeclarationAssignmentDeletedEvent(SelfDeclarationAssignmentDeletedPayload payload, Guid accountId) 
            : base(EventType.SelfDeclarationAssignmentDeleted, payload, accountId)
        {
        }
    }
}