using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Microsoft.Extensions.Logging;
using Restaurant.Shared;
using Microsoft.AspNetCore.Http;

namespace Restaurant.Web
{
   public class ApiHttpClient : IApiClient
   {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger<ApiHttpClient> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ApiHttpClient(IHttpClientFactory httpClientFactory, ILogger<ApiHttpClient> logger, IHttpContextAccessor httpContextAccessor)
        {
            _httpClientFactory = httpClientFactory ?? throw new ArgumentNullException(nameof(httpClientFactory));
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
        }

        private HttpClient GetHttpClientAsync()
        {
            var client = _httpClientFactory.CreateClient("Restaurant");
            client.DefaultRequestHeaders.Accept.Clear();
            client.SetBearerToken(_httpContextAccessor.HttpContext.Session.GetString("token")).SetHeader("ContentType", "application/json");
            return client;
        }

        public async Task<List<T>> GetListAsync<T>(string path)
        {
            return await GetAsync<List<T>>(path);
        }

        public async Task<T> GetAsync<T>(string path)
        {
            var client = GetHttpClientAsync();
            var result = await client.GetAsync<T>($"{path}", CheckErrorAsync);
            return result;
        }

        public async Task<T> PostAsync<T>(string path, object model)
        {
            var client = GetHttpClientAsync();
            var result = await client.PostAsync<T>($"{path}", model, CheckErrorAsync);
            return result;
        }

        private async Task CheckErrorAsync(HttpResponseMessage responseMessage)
        {
            if (responseMessage.StatusCode != HttpStatusCode.OK)
            {
                _logger.LogError(responseMessage.StatusCode + "\n" + await responseMessage.Content.ReadAsStringAsync());
                HandleErrors<object>(responseMessage.StatusCode, await responseMessage.Content.ReadAsStringAsync());
            }
        }

        private T HandleErrors<T>(HttpStatusCode? statusCode, string response)
        {
            _logger.LogError("Status Code : " + statusCode + ", " + response);
            if (statusCode == HttpStatusCode.Unauthorized || statusCode == HttpStatusCode.Forbidden || statusCode == HttpStatusCode.MethodNotAllowed)
                throw new AuthorizationException();
            if (statusCode == HttpStatusCode.Conflict)
                throw new BusinessRuleException((JsonConvert.DeserializeObject<dynamic>(response)).error.ToString());
            throw new BusinessRuleException("Unhandled Exception happened !!!");
        }
   }
}
