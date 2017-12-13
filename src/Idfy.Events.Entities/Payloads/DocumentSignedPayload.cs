using System;
using System.Collections.Generic;

namespace Idfy.Events.Entities
{
    public class DocumentSignedPayload : BaseDocumentPayload
    {
        public DateTime SignedTime { get; set; }

        public List<Signer> Signers { get; set; }
    }
}