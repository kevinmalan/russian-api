using EF.Contracts;
using EF.Entities;

namespace EF.CommandServices
{
    public class PhraseCommandService(DataContext dataContext) : IPhraseCommandService
    {
        public async Task CreateAsync(Phrase phrase)
        {
            await dataContext.Phrases.AddAsync(phrase);
            await dataContext.SaveChangesAsync();
        }
    }
}