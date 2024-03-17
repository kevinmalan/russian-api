namespace EF.Contracts
{
    public interface IPhraseQueryService
    {
        Task<List<Core.Models.Phrase>> GetAsync();
    }
}