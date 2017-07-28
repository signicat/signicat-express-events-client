using System;
using System.Collections.Generic;

namespace Idfy.Events.Entities.Sign
{
    public class DocumentSignedEvent : BaseDocumentEvent
    {
        public DateTime SignedTimeStamp { get; set; }

        public List<Signer> Signees { get; set; }
    }

    public class Signer
    {
        public Guid SignerId { get; set; }

        public string SignName { get; set; }

        public DateTime SignedTime { get; set; }

        public string DateOfBirth { get; set; }

        public string ExternalSignerId { get; set; }

        public string IdentityProviderId { get; set; }

        public string IdentityProvider { get; set; }

        public string SocialSecurityNumber { get; set; }

    }
}
