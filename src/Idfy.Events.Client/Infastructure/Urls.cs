namespace Idfy.Events.Client.Infastructure
{
    internal static class Urls
    {
        public static string BaseUrl => "https://api.idfy.io/";

        public static string NotificationEndpoint => $"{BaseUrl}notification";

        public static string TokenEndpoint => $"{BaseUrl}oauth/connect/token";
    }
}