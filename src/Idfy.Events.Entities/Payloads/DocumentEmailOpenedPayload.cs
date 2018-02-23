using System;

namespace Idfy.Events.Entities
{
    public class DocumentEmailOpenedPayload : BaseDocumentPayload
    {
        public string Email { get; set; }
        public Signer Signer { get; set; }
    }
}