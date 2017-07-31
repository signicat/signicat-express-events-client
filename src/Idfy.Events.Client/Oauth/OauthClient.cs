using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Caching;
using System.Security;

namespace Idfy.Events.Client.Oauth
{
    /// <summary>
    /// Client interface to get access token to our API
    /// </summary>
    public interface IOauthClient
    {
        string GetAccessToken(string scope);
    }

    /// <summary>
    /// Client to get access token to our API
    /// </summary>
    public class OauthClient : IOauthClient
    {
        private readonly string _clientId;
        private readonly string _secret;
        private readonly string _oauthTokenUrl; 
        private readonly MemoryCache _cache;

        public OauthClient(string clientId, string secret, string oauthTokenUrl)
        {
            _clientId = clientId;
            _secret = secret;
            _cache = MemoryCache.Default;
            _oauthTokenUrl = oauthTokenUrl;
        }

        public OauthClient(string clientId, string secret, OauthTokenEndpoint oauthTokenEndpoint)
        {
            _clientId = clientId;
            _secret = secret;
            _cache = MemoryCache.Default;
            switch (oauthTokenEndpoint)
            {
                case OauthTokenEndpoint.SignereTest:
                    _oauthTokenUrl = OauthEnpoints.TokenEndpointTest;
                    break;
                case OauthTokenEndpoint.SignereProd:
                    _oauthTokenUrl = OauthEnpoints.TokenEndpointProd;
                    break;
                default:
                    _oauthTokenUrl = OauthEnpoints.TokenEndpointTest;
                    break;
            }
        }
        
        public string GetAccessToken(string scope)
        {
            var cacheKey = $"token:{_clientId}-{scope}";
            if (_cache.Contains(cacheKey))
            {
                var cachedToken = _cache[cacheKey] as SecureString;
                return Extensions.SecureStringToString(cachedToken);
            }

            var headervalue = new AuthenticationHeaderValue("Basic",
                Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes($"{_clientId}:{_secret}")));

            var pairs = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("grant_type", "client_credentials"),
                new KeyValuePair<string, string>("scope", scope)
            });

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = headervalue;
                client.DefaultRequestHeaders
                    .Accept
                    .Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var result = Extensions.RunSync(() => client.PostAsync(_oauthTokenUrl, pairs));

                if (result.IsSuccessStatusCode)
                {
                    var raw = Extensions.RunSync(() => result.Content.ReadAsStringAsync());
                    var tokenData = Extensions.Deserialize<AccessToken>(raw);
                    var secureToken = Extensions.ToSecureString(tokenData.access_token);
                    _cache.Add(cacheKey, secureToken, DateTimeOffset.UtcNow.AddSeconds(tokenData.expires_in - 1000));
                    return tokenData.access_token;
                }
                else
                {
                    throw new Exception($"Error getting access token, status code: {result.StatusCode}");
                }
            }
        }
    }
}