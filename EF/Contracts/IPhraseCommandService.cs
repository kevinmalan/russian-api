using EF.Entities;

namespace EF.Contracts
{
    public interface IPhraseCommandService
    {
        Task CreateAsync(Phrase phrase);
    }
}