using EF.Entities;

namespace EF.Contracts
{
    public interface IAlphabetQueryService
    {
        Task<List<Alphabet>> GetAsync();
    }
}