using System;
using Idfy.Events.Entities;

namespace Idfy.Events.Entities
{
    public class SelfDeclarationFinishedPayload : BaseDepositPayload
    {
        public Guid PersonId { get; set; }
    }
}