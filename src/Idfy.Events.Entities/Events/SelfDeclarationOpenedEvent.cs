using System;

namespace Idfy.Events.Entities
{
    public class SelfDeclarationOpenedEvent : Event<SelfDeclarationOpenedPayload>
    {
        public SelfDeclarationOpenedEvent(SelfDeclarationOpenedPayload payload, Guid accountId) :
            base(EventType.SelfDeclarationOpened, payload, accountId)
        {
        }
    }
}