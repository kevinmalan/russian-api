namespace Core.Contracts
{
    public interface IAlphabetService
    {
        Task<List<API.Dtos.Alphabet>> GetAsync();
    }
}