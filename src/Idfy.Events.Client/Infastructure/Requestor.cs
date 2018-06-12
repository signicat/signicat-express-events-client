using System;
using System.Collections.Specialized;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Idfy.Events.Client.Infastructure
{
    internal static class Requestor
    {
        internal static HttpClient HttpClient { get; private set; }
        
        static Requestor()
        {
            HttpClient = new HttpClient();
        }

        public static IdfyResponse GetString(string url, string token = null)
        {
            var request = GetRequestMessage(url, HttpMethod.Get, token);

            return ExecuteRequest(request);
        }

        public static Task<IdfyResponse> GetStringAsync(string url, string token = null)
        {
            var request = GetRequestMessage(url, HttpMethod.Get, token);

            return ExecuteRequestAsync(request);
        }

        public static IdfyResponse PostFormData(string url, NameValueCollection formData, string token = null)
        {
            var request = GetRequestMessage(url, HttpMethod.Post, formData: formData);

            return ExecuteRequest(request);
        }
        
        public static Task<IdfyResponse> PostFormDataAsync(string url, NameValueCollection formData, string token = null)
        {
            var request = GetRequestMessage(url, HttpMethod.Post, formData: formData);

            return ExecuteRequestAsync(request);
        }

        public static IdfyResponse PostString(string url, string jsonBody = null, string token = null)
        {
            var request = GetRequestMessage(url, HttpMethod.Post, token, jsonBody);

            return ExecuteRequest(request);
        }

        public static Task<IdfyResponse> PostStringAsync(string url, string jsonBody = null, string token = null)
        {
            var request = GetRequestMessage(url, HttpMethod.Post, token, jsonBody);

            return ExecuteRequestAsync(request);
        }

        private static HttpRequestMessage GetRequestMessage(string url, HttpMethod method, string token = null, string jsonBody = null, NameValueCollection formData = null)
        {
            var request = BuildRequest(url, method, jsonBody, formData);

            if (!string.IsNullOrWhiteSpace(token))
            {
                request.Headers.Add("Authorization", $"Bearer {token}");
            }

            return request;
        }

        private static HttpRequestMessage BuildRequest(string url, HttpMethod method, string jsonBody = null, NameValueCollection formData = null)
        {
            if (method != HttpMethod.Post)
                return new HttpRequestMessage(method, new Uri(url));

            var postData = jsonBody;
            var contentType = "application/json";

            if (string.IsNullOrWhiteSpace(jsonBody) && formData != null)
            {
                postData = formData.ToQueryString().Substring(1);
                contentType = "application/x-www-form-urlencoded";
            }

            return new HttpRequestMessage(method, new Uri(url))
            {
                Content = !string.IsNullOrWhiteSpace(postData)
                    ? new StringContent(postData, Encoding.UTF8, contentType)
                    : null
            };
        }

        private static IdfyResponse ExecuteRequest(HttpRequestMessage requestMessage)
        {
            var response = AsyncHelper.RunSync(() => HttpClient.SendAsync(requestMessage));
            var content = AsyncHelper.RunSync(() => response.Content.ReadAsStringAsync());
            
            var result = BuildResponseData(response, content);

            if (response.IsSuccessStatusCode)
                return result;

            throw BuildIdfyException(result, response.StatusCode, requestMessage.RequestUri.AbsoluteUri, content);
        }

        private static async Task<IdfyResponse> ExecuteRequestAsync(HttpRequestMessage requestMessage)
        {
            var response = await HttpClient.SendAsync(requestMessage);
            var content = await response.Content.ReadAsStringAsync();
            
            var result = BuildResponseData(response, content);

            if (response.IsSuccessStatusCode)
                return result;

            throw BuildIdfyException(result, response.StatusCode, requestMessage.RequestUri.AbsoluteUri, content);
        }

        private static IdfyException BuildIdfyException(IdfyResponse response, HttpStatusCode statusCode, string requestUri, string responseContent)
        {
            var idfyError = Mapper<IdfyError>.MapFromJson(responseContent, response);

            return new IdfyException(statusCode, idfyError, idfyError.Message)
            {
                IdfyResponse = response
            };
        }

        private static IdfyResponse BuildResponseData(HttpResponseMessage response, string responseText)
        {
            return new IdfyResponse()
            {
                RequestId = response.Headers.Contains("Request-Id")? response.Headers.GetValues("Request-Id").First(): "n/a",
                RequestDate = Convert.ToDateTime(response.Headers.GetValues("Date").First(), CultureInfo.InvariantCulture),
                ResponseJson = responseText
            };
        }
    }
}