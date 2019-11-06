using System;

namespace Idfy.Events.Entities
{
    public class SelfDeclarationAssignmentFinishedEvent : Event<SelfDeclarationAssignmentFinishedPayload>
    {
        public SelfDeclarationAssignmentFinishedEvent(SelfDeclarationAssignmentFinishedPayload payload, Guid accountId) :
            base(EventType.SelfDeclarationAssignmentFinished, payload, accountId)
        {
        }
    }
}