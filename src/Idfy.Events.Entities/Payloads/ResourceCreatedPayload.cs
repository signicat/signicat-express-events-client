namespace Idfy.Events.Entities
{
    public class ResourceCreatedPayload
    {
        public string SourceType { get; set; }

        public string SourceId { get; set; }
        
        public string ResourceId { get; set; }
        
        public ResourceLink Link { get; set; }
    }

    public class ResourceLink
    {
        public string Href { get; set; }
        
        public string Rel { get; set; }

        public string ContentType { get; set; }

        public string Error { get; set; }
    }
}