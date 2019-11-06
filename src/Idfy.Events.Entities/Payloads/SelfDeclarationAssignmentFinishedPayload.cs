using System;
using Idfy.Events.Entities;

namespace Idfy.Events.Entities
{
    public class SelfDeclarationAssignmentFinishedPayload : BaseDepositPayload
    {
        public Guid AssignmentId { get; set; }
    }
}