using EF.Contracts;
using EF.Entities;
using Microsoft.EntityFrameworkCore;

namespace EF.QueryServices
{
    public class PhraseQueryService(DataContext dataContext) : IPhraseQueryService
    {
        public async Task<List<Phrase>> GetAsync()
        {
            return await dataContext.Phrases.ToListAsync();
        }
    }
}