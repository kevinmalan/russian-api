using UI.Services.Contracts;

namespace UI.Services
{
    public class ApiService(HttpClient httpClient) : IApiService
    {
        public async Task<string> GetAlphabetAsync()
        {
            var response = await httpClient.GetAsync("https://localhost:7104/api/Alphabet");
            var content = await response.Content.ReadAsStringAsync();

            return content;
        }
    }
}
