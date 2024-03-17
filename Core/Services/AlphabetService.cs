using Core.Contracts;
using Core.Models;
using EF.Contracts;

namespace Core.Services
{
    public class AlphabetService(IAlphabetQueryService alphabetQueryService) : IAlphabetService
    {
        public async Task<List<Alphabet>> GetAsync()
        {
            return await alphabetQueryService.GetAsync();
        }
    }
}