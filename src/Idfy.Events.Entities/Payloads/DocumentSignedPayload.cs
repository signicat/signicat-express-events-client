using System;
using System.Collections.Generic;

namespace Idfy.Events.Entities
{
    public class DocumentSignedPayload : BaseDocumentPayload
    {
        public DateTime SignedTimeStamp { get; set; }

        public List<Signer> Signees { get; set; }
    }
}