using Core.Constants;
using Core.Contracts;
using Core.Models;
using EF.Contracts;
using static Core.Mappers.AlphabetMapper;

namespace Core.Services
{
    public class AlphabetService(
        IAlphabetQueryService alphabetQueryService,
        ICacheService<object> cache)
        : IAlphabetService
    {
        public async Task<List<Alphabet>> GetAsync()
        {
            if (cache.GetCache(CacheKey.Alphabet) is List<Alphabet> cachedAlphabet)
                return cachedAlphabet;

            var entities = await alphabetQueryService.GetAsync();
            var models = entities.Select(x => x.MapToModel()).ToList();

            cache.SetCache(CacheKey.Alphabet, models, TimeSpan.FromHours(24));

            return models;
        }
    }
}