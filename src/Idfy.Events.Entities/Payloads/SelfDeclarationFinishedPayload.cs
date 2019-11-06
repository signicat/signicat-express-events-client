using System;
using Idfy.Events.Entities;

namespace Idfy.Events.Entities
{
    public class SelfDeclarationFinishedPayload : BaseSelfDeclarationPayload
    {
        public Guid PersonId { get; set; }
    }
}