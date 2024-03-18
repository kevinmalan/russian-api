using Core.Models;

namespace Core.Contracts
{
    public interface IAlphabetService
    {
        Task<List<Alphabet>> GetAsync();
    }
}