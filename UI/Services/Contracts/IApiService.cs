using Shared.Dtos;

namespace UI.Services.Contracts
{
    public interface IApiService
    {
        Task<List<Alphabet>> GetAlphabetAsync();
        Task<List<Phrase>> GetPhrasesAsync();
        Task<Phrase> CreatePhraseAsync(Phrase phrase);
    }
}
