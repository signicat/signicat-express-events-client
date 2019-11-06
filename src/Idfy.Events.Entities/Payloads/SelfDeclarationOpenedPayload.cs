using System;
using Idfy.Events.Entities;

namespace Idfy.Events.Entities
{
    public class SelfDeclarationOpenedPayload : BaseSelfDeclarationPayload
    {
        public Guid PersonId { get; set; }
    }
}