using System;
using System.Collections.Generic;
using Idfy.Events.Entities.Sign;

namespace Idfy.Events.Entities.Events
{
    public class DocumentSignedPayload : BaseDocumentPayload
    {
        public DateTime SignedTimeStamp { get; set; }

        public List<Signer> Signees { get; set; }
    }
}