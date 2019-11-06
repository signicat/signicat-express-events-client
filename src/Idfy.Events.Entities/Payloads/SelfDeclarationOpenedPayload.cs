using System;
using Idfy.Events.Entities;

namespace Idfy.Events.Entities
{
    public class SelfDeclarationOpenedPayload : BaseDepositPayload
    {
        public Guid PersonId { get; set; }
    }
}