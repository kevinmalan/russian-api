namespace EF.Contracts
{
    public interface IAlphabetQueryService
    {
        Task<List<Core.Models.Alphabet>> GetAsync();
    }
}