using System.Collections.Generic;

namespace Idfy.Events.Entities
{
    public class ShareReceipientDownloadedPayload: BaseSharePayload
    {
        public string RecipientId { get; set; }
        public string RecipientExternalId { get; set; }   
        public List<string> ContentIdList{ get; set; }
    }
}