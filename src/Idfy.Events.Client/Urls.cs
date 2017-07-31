namespace Idfy.Events.Client
{
    public static class Urls
    {
        public const string SignatureApiTest = "https://signaturetest.idfy.io";
        public const string SignatureApiProd = "https://signature.idfy.io";
        public const string EventsApiTest = "https://eventstest.idfy.io";
        public const string EventsApiProd = "https://events.idfy.io";
    }

    internal static class OauthEnpoints
    {
        public static string TokenEndpointTest => "https://oauth2test.signere.com/connect/token";
        public static string TokenEndpointProd => "https://oauth.signere.no/connect/token";
    }


}