using Newtonsoft.Json;
using Shared.Dtos;
using Shared.Routes;
using System.Text;
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

        public async Task<List<Phrase>> GetPhrasesAsync()
        {
            var uri = new Uri($"{_baseUrl}/{PhraseRoute.Get}");
            var response = await httpClient.GetAsync(uri);

            if (!response.IsSuccessStatusCode)
            {
                // TODO
            }

            var content = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<Phrase>>(content);

            return result ?? [];
        }

        public async Task<Phrase> CreatePhraseAsync(Phrase phrase)
        {
            var uri = new Uri($"{_baseUrl}/{PhraseRoute.Create}");
            var json = JsonConvert.SerializeObject(phrase);
            var payload = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync(uri, payload);

            if (!response.IsSuccessStatusCode)
            {
                // TODO
            }

            var content = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<Phrase>(content);

            return result;
        }
    }
}