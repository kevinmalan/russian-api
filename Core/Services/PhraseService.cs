using Core.Contracts;
using Core.Models;
using EF.Contracts;
using System.Text;
using static Core.Mappers.AlphabetMapper;
using static Core.Mappers.PhraseMapper;

namespace Core.Services
{
    public class PhraseService(
        IPhraseQueryService phraseQueryService,
        IPhraseCommandService phraseCommandService,
        IAlphabetQueryService alphabetQueryService) : IPhraseService
    {
        public async Task<List<Phrase>> GetAsync()
        {
            // Entities
            var alphabetEntities = await alphabetQueryService.GetAsync();
            var phraseEntities = await phraseQueryService.GetAsync();

            // Models
            var alphabetModels = alphabetEntities.Select(x => x.MapToModel()).ToList();
            var phraseModels = phraseEntities.Select(x => x.MapToModel()).ToList();


            foreach (var phraseModel in phraseModels)
            {
                phraseModel.NonCyrillicRussian = GetNonCyrillicRussian(phraseModel.Russian ?? "", alphabetModels);
            }

            return phraseModels;
        }

        public async Task CreateAsync(Phrase phrase)
        {
            var entity = phrase.MapToEntity();
            await phraseCommandService.CreateAsync(entity);
        }

        private static string GetNonCyrillicRussian(string cyrillicRussianPhrase, List<Alphabet> alphabet)
        {
            var sb = new StringBuilder();
            foreach (var letter in cyrillicRussianPhrase)
            {
                // https://en.wikipedia.org/wiki/List_of_Unicode_characters
                // Cyrillic Unicode code point
                if (letter >= 1024 && letter <= 1279)
                {
                    var item = alphabet.First(x => string.Compare(x.Russian, $"{letter}", ignoreCase: true) != -1);
                    sb.Append(item.English);
                    continue;
                }

                sb.Append(letter);
            }

            return sb.ToString();
        }
    }
}