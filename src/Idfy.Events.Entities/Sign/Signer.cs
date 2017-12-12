using System;

namespace Idfy.Events.Entities
{
    public class Signer
    {
        public Guid Id { get; set; }

        public string FullName { get; set; }

        public DateTime SignedTime { get; set; }

        public string DateOfBirth { get; set; }

        public string ExternalSignerId { get; set; }

        public string SignatureMethod { get; set; }

        public string SignatureMethodUniqueId { get; set; }

        public string SocialSecurityNumber { get; set; }

    }
}