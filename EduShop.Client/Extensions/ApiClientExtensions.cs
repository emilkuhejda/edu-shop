using Newtonsoft.Json;
using System.Runtime.Serialization;
using System.Text;
using EduShop.Client.Http;

namespace EduShop.Client.Extensions
{
    internal static class ApiClientExtensions
    {
        public static Task<T> SendGetAsync<T>(this HttpClient httpClient, string path) where T : new()
            => SendAsync<T>(httpClient, HttpMethod.Get, path, null);

        public static Task SendPostAsync(this HttpClient httpClient, string path, object contract)
            => SendAsync<NoResult>(httpClient, HttpMethod.Post, path, contract);

        public static Task SendPutAsync(this HttpClient httpClient, string path, object contract)
            => SendAsync<NoResult>(httpClient, HttpMethod.Put, path, contract);

        public static Task SendDeleteAsync(this HttpClient httpClient, string path)
            => SendAsync<NoResult>(httpClient, HttpMethod.Delete, path, null);

        private static async Task<T> SendAsync<T>(this HttpClient httpClient, HttpMethod httpMethod, string path, object? contract) where T : new()
        {
            using var cts = new CancellationTokenSource();
            var requestMessage = CreateRequestMessage(httpMethod, CreateUri(httpClient, path), contract != null ? SerializeJsonContent(contract) : null);
            var response = await httpClient.SendAsync(requestMessage, cts.Token);
            response.EnsureSuccessStatusCode();

            if (typeof(T) == typeof(NoResult))
                return new T();

            var content = await response.Content.ReadAsStringAsync(cts.Token);
            return JsonConvert.DeserializeObject<T>(content) ?? throw new SerializationException();
        }

        private static Uri CreateUri(HttpClient httpClient, string path)
        {
            return new Uri(httpClient.BaseAddress!, path.TrimStart('/'));
        }

        private static HttpRequestMessage CreateRequestMessage(HttpMethod method, Uri uri, HttpContent? content)
            => new(method, uri) { Content = content };

        private static StringContent SerializeJsonContent(object contract)
        {
            var jsonContent = JsonConvert.SerializeObject(contract);
            return new StringContent(jsonContent, Encoding.UTF8, "application/json");
        }
    }
}
