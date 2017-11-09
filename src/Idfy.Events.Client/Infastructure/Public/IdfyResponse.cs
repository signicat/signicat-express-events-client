using System;

namespace Idfy.Events.Client.Infastructure
{
    public class IdfyResponse
    {
        public string ResponseJson { get; set; }
        public string RequestId { get; set; }
        public DateTime RequestDate { get; set; }
    }
}