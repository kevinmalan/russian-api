using Core.Contracts;
using EF.Contracts;
using static Core.Mappers.AlphabetMapper;

namespace Core.Services
{
    public class AlphabetService(IAlphabetQueryService alphabetQueryService) : IAlphabetService
    {
        public async Task<List<API.Dtos.Alphabet>> GetAsync()
        {
            var models = await alphabetQueryService.GetAsync();

            return models.Select(x => x.MapToDto()).ToList();
        }
    }
}