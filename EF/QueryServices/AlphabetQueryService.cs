using EF.Contracts;
using EF.Entities;
using Microsoft.EntityFrameworkCore;

namespace EF.QueryServices
{
    public class AlphabetQueryService(DataContext dataContext) : IAlphabetQueryService
    {
        public async Task<List<Alphabet>> GetAsync()
        {
            return await dataContext.Alphabet.ToListAsync();
        }
    }
}