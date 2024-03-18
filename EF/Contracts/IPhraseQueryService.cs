using EF.Entities;

namespace EF.Contracts
{
    public interface IPhraseQueryService
    {
        Task<List<Phrase>> GetAsync();
    }
}