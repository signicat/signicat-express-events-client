using System;
using System.Dynamic;
using System.Security.Cryptography.X509Certificates;
using Idfy.Events.Entities.Payloads;

namespace Idfy.Events.Entities.Events
{
    public class DocumentCanceledEvent : Event<DocumentCanceledPayload>
    {
        public DocumentCanceledEvent(Guid accountId, DocumentCanceledPayload payload) 
            : base(EventType.DocumentCanceled, payload, accountId)
        {
        }
    }
}