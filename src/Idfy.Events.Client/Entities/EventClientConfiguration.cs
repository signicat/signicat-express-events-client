using System;
using Newtonsoft.Json;

namespace Idfy.Events.Client
{
    public class EventClientConfiguration
    {
        [JsonProperty("connectionString")]
        public string ConnectionString { get; set; }
        
        [JsonProperty("encryptionKey")]
        public string EncryptionKey { get; set; }

        [JsonProperty("accountId")]
        public Guid AccountId { get; set; }
    }
}