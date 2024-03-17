using Core.Contracts;
using EF.Contracts;
using System.Text;

namespace Core.Services
{
    public class PhraseService(IPhraseQueryService phraseQueryService, IAlphabetQueryService alphabetQueryService) : IPhraseService
    {
        public async Task<List<API.Dtos.Phrase>> GetAsync()
        {
            var phraseModels = await phraseQueryService.GetAsync();
            var alphabetModels = await alphabetQueryService.GetAsync();

            return phraseModels.Select(x => new API.Dtos.Phrase
            {
                Category = x.Category,
                English = x.English,
                Russian = x.Russian,
                UniqueId = x.UniqueId,
                NonCyrillicRussian = GetNonCyrillicRussian(x?.Russian ?? "", alphabetModels)
            }).ToList();
        }

        private static string GetNonCyrillicRussian(string cyrillicRussianPhrase, List<Models.Alphabet> alphabet)
        {
            var sb = new StringBuilder();
            foreach (var letter in cyrillicRussianPhrase)
            {
                var item = alphabet.First(x => string.Compare(x.Russian, $"{letter}", ignoreCase: true) != -1);
                sb.Append(item.English);
            }

            return sb.ToString();
        }
    }
}