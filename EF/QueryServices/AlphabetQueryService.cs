using EF.Contracts;
using Microsoft.EntityFrameworkCore;
using static EF.Mappers.AlphabetMapper;

namespace EF.QueryServices
{
    public class AlphabetQueryService(DataContext dataContext) : IAlphabetQueryService
    {
        public async Task<List<Core.Models.Alphabet>> GetAsync()
        {
            var entities = await dataContext.Alphabet.ToListAsync();

            return entities.Select(x => x.MapToModel()).ToList();
        }
    }
}