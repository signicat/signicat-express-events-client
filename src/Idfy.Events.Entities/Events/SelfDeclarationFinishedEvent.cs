using System;

namespace Idfy.Events.Entities
{
    public class SelfDeclarationFinishedEvent : Event<SelfDeclarationFinishedPayload>
    {
        public SelfDeclarationFinishedEvent(SelfDeclarationFinishedPayload payload, Guid accountId) :
            base(EventType.SelfDeclarationFinished, payload, accountId)
        {
        }
    }
}