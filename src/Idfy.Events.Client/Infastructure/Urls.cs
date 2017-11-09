namespace Idfy.Events.Client.Infastructure
{
    internal static class Urls
    {
        public static string SignatureApiTest => "https://sign-api-test.idfy.io";
        
        public static string SignatureApiProd => "https://signature.idfy.io";
        
        public static string EventsApiTest => "http://event-test.idfy.io/api";
        
        public static string EventsApiProd => "https://events.idfy.io/api";
        
        public static string OauthTest => "https://oauth2test.signere.com/connect/token";
        
        public static string OauthProd => "https://oauth.signere.no/connect/token";
    }
}