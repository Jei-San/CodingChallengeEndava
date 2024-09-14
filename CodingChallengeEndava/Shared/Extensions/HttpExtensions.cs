using Newtonsoft.Json;

namespace CodingChallengeEndava.Shared.Extensions
{
    public static class HttpExtensions
    {
        public static async Task<T?> GetAndDeserialize<T>(this HttpClient client, string requestUri)
        {
            var response = await client.GetAsync(requestUri);
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(result);
        }
    }
}
