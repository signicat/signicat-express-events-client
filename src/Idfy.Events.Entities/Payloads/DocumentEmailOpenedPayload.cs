using System;

namespace Idfy.Events.Entities
{
    public class DocumentEmailOpenedPayload : BaseDocumentPayload
    {
        public Guid SignerId { get; set; }
        public string Email { get; set; }
    }
}