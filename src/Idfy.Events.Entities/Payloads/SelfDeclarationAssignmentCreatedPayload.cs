using System;
using Idfy.Events.Entities;

namespace Idfy.Events.Entities
{
    public class SelfDeclarationAssignmentCreatedPayload : BaseDepositPayload
    {
        public Guid PersonId { get; set; }
    }
}