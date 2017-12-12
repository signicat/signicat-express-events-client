using System;

namespace Idfy.Events.Entities
{
    public class DocumentPartiallySignedPayload : BaseDocumentPayload
    {
       public Signer Signer { get; set; }
    }
}