using System;
using System.Collections.Generic;

namespace Idfy.Events.Entities
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