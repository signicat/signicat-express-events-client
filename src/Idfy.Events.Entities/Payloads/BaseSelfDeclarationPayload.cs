using System;

namespace Idfy.Events.Entities
{
    public class BaseSelfDeclarationPayload
    {
        public Guid AssignmentId { get; set; }
        public string ExternalId { get; set; }
    }
}