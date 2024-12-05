using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using VehicleInfoApp.Abstraction;


namespace VehicleInfoApp.IntegrationUtilities
{
    public class HttpClientCallers<T>(ILogger logger, string rootApiUrl) : IHttpclientCallers<T> where T : class
    {
        private readonly ILogger _logger = logger;
        private readonly string _RootURL = rootApiUrl;


        public async Task<T> GetRequest(string? relativeURL=null, Dictionary<string, string> HeaderOptions = null)
        {
            T result = default;
            try
            {
                using HttpClient client = new HttpClient();

                HttpResponseMessage response = await client.GetAsync(_RootURL+ relativeURL).ConfigureAwait(false);

                if (response.IsSuccessStatusCode)
                {
                    await response.Content.ReadAsStringAsync().ContinueWith(async (Task<string> x) =>
                    {
                        string data = await x;
                        result = JsonConvert.DeserializeObject<T>(data);
                    });

                }
                else
                {
                    var content = await response.Content.ReadAsStringAsync();
                    response.Content?.Dispose();
                    throw new HttpRequestException($"{response.StatusCode}:{content}");
                }
            }
            catch (Exception ex)
            {

                _logger.LogError(ex, ex.Message);
            }
            return result;
        }
    }
}
