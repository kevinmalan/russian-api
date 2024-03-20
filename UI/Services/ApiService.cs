using Newtonsoft.Json;
using Shared.Dtos;
using Shared.Routes;
using UI.Services.Contracts;

namespace UI.Services
{
    public class ApiService(HttpClient httpClient, IConfiguration configuration) : IApiService
    {
        private readonly string _baseUrl = configuration["RussianAPI:BaseUrl"] ?? throw new Exception("Config 'RussianAPI:BaseUrl' not found.");

        public async Task<List<Alphabet>> GetAlphabetAsync()
        {
            var uri = new Uri($"{_baseUrl}/{AlphabetRoute.Get}");
            var response = await httpClient.GetAsync(uri);

            if (!response.IsSuccessStatusCode)
            {
                // TODO
            }

            var content = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<Alphabet>>(content);

            return result ?? [];
        }
    }
}