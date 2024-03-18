using Core.Contracts;
using Core.Models;
using EF.Contracts;
using static Core.Mappers.AlphabetMapper;

namespace Core.Services
{
    public class AlphabetService(IAlphabetQueryService alphabetQueryService) : IAlphabetService
    {
        public async Task<List<Alphabet>> GetAsync()
        {
            var entities = await alphabetQueryService.GetAsync();

            return entities.Select(x => x.MapToModel()).ToList();
        }
    }
}