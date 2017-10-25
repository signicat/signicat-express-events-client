using System;
using System.Collections.Generic;
using Idfy.Events.Entities.Sign;

namespace Idfy.Events.Entities.Payloads
{
    public class DocumentFormSignedPayload : BaseDocumentPayload
    {
        public DateTime SignedTimeStamp { get; set; }
        public Guid SchemaId { get; set; }
        public string Schema { get; set; }
        public List<Signer> Signees { get; set; }
        public Dictionary<string, string> FormFields { get; set; }
    }
}