﻿using System;

namespace Idfy.Events.Entities.Sign
{
    public class DocumentPartiallySignedEvent : BaseDocumentEvent
    {
        public Guid SignerId { get; set; }

        public string SignName { get; set; }

        public DateTime SignedTime { get; set; }

        public string DateOfBirth { get; set; }

        public string ExternalSignerId { get; set; }

        public string SignatureMethodUniqueId { get; set; }

        public string SignatureMethod { get; set; }

        public string SocialSecurityNumber { get; set; }
    }
}