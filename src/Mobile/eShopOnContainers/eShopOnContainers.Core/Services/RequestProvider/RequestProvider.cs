using Microsoft.eShopOnContainers.BuildingBlocks.Resilience.HttpResilience;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace eShopOnContainers.Core.Services.RequestProvider
{
    public class RequestProvider : IRequestProvider
    {
        private readonly IHttpClient _httpClient;
        private readonly JsonSerializerSettings _serializerSettings;

        public RequestProvider(IHttpClient httpClient)
        {
            _httpClient = httpClient;

            _serializerSettings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                DateTimeZoneHandling = DateTimeZoneHandling.Utc,
                NullValueHandling = NullValueHandling.Ignore
            };

            _serializerSettings.Converters.Add(new StringEnumConverter());
        }

        public async Task<TResult> GetAsync<TResult>(string uri, string token = "")
        {
            IHttpClient httpClient = GetHttpClientWithHeaders(token);
            string serialized = await httpClient.GetStringAsync(uri);

            TResult result = await Task.Run(() => 
                JsonConvert.DeserializeObject<TResult>(serialized, _serializerSettings));

            return result;
        }

        public async Task<TResult> PostAsync<TResult>(string uri, TResult data, string token = "", string header = "")
        {
            IHttpClient httpClient = GetHttpClientWithHeaders(token);

            if (!string.IsNullOrEmpty(header))
            {
                AddHeaderParameter(httpClient.Inst, header);
            }

            HttpResponseMessage response = await httpClient.PostAsync(uri, data);
            string serialized = await response.Content.ReadAsStringAsync();

            TResult result = await Task.Run(() =>
                JsonConvert.DeserializeObject<TResult>(serialized, _serializerSettings));

            return result;
        }

        public Task<TResult> PostAsync<TResult>(string uri, TResult data, string token = "")
        {
            return PostAsync<TResult, TResult>(uri, data, token);
        }

        public async Task<TResult> PostAsync<TRequest, TResult>(string uri, TRequest data, string token = "")
        {
            IHttpClient httpClient = GetHttpClientWithHeaders(token);
            HttpResponseMessage response = await httpClient.PostAsync(uri, data);

            string responseData = await response.Content.ReadAsStringAsync();

            return await Task.Run(() => JsonConvert.DeserializeObject<TResult>(responseData, _serializerSettings));
        }

        public async Task DeleteAsync(string uri, string token = "")
        {
            IHttpClient httpClient = GetHttpClientWithHeaders(token);

            await httpClient.DeleteAsync(uri);
        }

        private IHttpClient GetHttpClientWithHeaders(string token = "")
        {
            var httpClient = _httpClient.Inst;

            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            if (!string.IsNullOrEmpty(token))
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }

            return _httpClient;
        }

        private void AddHeaderParameter(HttpClient httpClient, string parameter)
        {
            if (httpClient == null)
                return;

            if (string.IsNullOrEmpty(parameter))
                return;

            httpClient.DefaultRequestHeaders.Add(parameter, Guid.NewGuid().ToString());
        }
    }
}
