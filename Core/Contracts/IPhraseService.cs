namespace Core.Contracts
{
    public interface IPhraseService
    {
        Task<List<API.Dtos.Phrase>> GetAsync();
    }
}