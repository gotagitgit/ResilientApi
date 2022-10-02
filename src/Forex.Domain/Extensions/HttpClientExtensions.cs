using Forex.Domain.Factories;

namespace Forex.Domain.Extensions
{
    internal static class HttpClientExtensions
    {
        public static async Task<HttpResponseMessage> GetAsync(this ForexHttpClient client, Uri uri)
        {
            using var request = new HttpRequestMessage(HttpMethod.Get, uri);

            var responseMessage = await client.SendAsync(request);

            return responseMessage;
        }
    }
}
