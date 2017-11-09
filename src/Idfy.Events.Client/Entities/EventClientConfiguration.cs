using Newtonsoft.Json;

namespace Idfy.Events.Client
{
    public class EventClientConfiguration
    {
        [JsonProperty("connectionString")]
        public string ConnectionString { get; set; }
        
        [JsonProperty("encryptionKey")]
        public string EncryptionKey { get; set; }
    }
}