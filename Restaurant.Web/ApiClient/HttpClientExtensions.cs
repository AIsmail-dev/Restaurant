using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Web
{
    public static class HttpClientExtensions
    {
        public static HttpClient SetBasicAuthentication(this HttpClient httpClient, string username, string password)
        {
            var credentials = Convert.ToBase64String(Encoding.UTF8.GetBytes($"{username}:{password}"));
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", credentials);
            return httpClient;
        }

        public static HttpClient SetBearerToken(this HttpClient httpClient, string token)
        {
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            return httpClient;
        }

        public static HttpClient SetHeader(this HttpClient httpClient, string name, object value)
        {
            httpClient.DefaultRequestHeaders.Add(name, value.ToString());
            return httpClient;
        }

        public static async Task<T> GetAsync<T>(this HttpClient httpClient, string url, Func<HttpResponseMessage, Task> CheckErrorAsync)
        {
            var response = await httpClient.GetAsync(url, HttpCompletionOption.ResponseHeadersRead);
            await CheckErrorAsync(response);
            using var stream = await response.Content.ReadAsStreamAsync();
            using var streamReader = new StreamReader(stream);
            using var reader = new JsonTextReader(streamReader);
            var serializer = new JsonSerializer();

            return serializer.Deserialize<T>(reader);
        }

        public static async Task<T> PostAsync<T>(this HttpClient httpClient, string url, object content, Func<HttpResponseMessage, Task> CheckErrorAsync)
        {
            var data = await httpClient.PostAsync(url, content, CheckErrorAsync);
            return JsonConvert.DeserializeObject<T>(data);
        }

        public static async Task<string> PostAsync(this HttpClient httpClient, string url, object content, Func<HttpResponseMessage, Task> CheckErrorAsync)
        {
            var response = await httpClient.PostAsync(url, CreateHttpContent(content));
            await CheckErrorAsync(response);
            using var stream = await response.Content.ReadAsStreamAsync();
            using var streamReader = new StreamReader(stream);
            return await streamReader.ReadToEndAsync();
        }

        private static HttpContent CreateHttpContent<T>(T content)
        {
            var json = JsonConvert.SerializeObject(content);
            return new StringContent(json, Encoding.UTF8, "application/json");
        }
    }

    [DataContract]
    public class ResponseMessage
    {
        [DataMember(Name = "IsSuccess")]
        public bool IsSuccess { get; set; }

        [DataMember(Name = "ReturnMessage")]
        public string ReturnMessage { get; set; }
    }
}
