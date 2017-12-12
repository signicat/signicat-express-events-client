using System;
using System.Collections.Generic;

namespace Idfy.Events.Entities
{
    public class DocumentFormPartiallySignedPayload : BaseDocumentPayload
    {
        public Guid SchemaId { get; set; }
        
        public string Schema { get; set; }
        
        public Dictionary<string, string> FormFields { get; set; }
        
        public Signer Signer { get; set; }
    }
}