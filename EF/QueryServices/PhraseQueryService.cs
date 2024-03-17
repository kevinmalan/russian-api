using EF.Contracts;
using EF.Mappers;
using Microsoft.EntityFrameworkCore;
using static EF.Mappers.PhraseMapper;

namespace EF.QueryServices
{
    public class PhraseQueryService(DataContext dataContext) : IPhraseQueryService
    {
        public async Task<List<Core.Models.Phrase>> GetAsync()
        {
            var entities = await dataContext.Phrases.ToListAsync();

            return entities.Select(x => x.MapToModel()).ToList();
        }
    }
}