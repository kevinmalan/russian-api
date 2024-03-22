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
            var phraseEntities = await phraseQueryService.GetAsync();
            var phraseModels = phraseEntities.Select(x => x.MapToModel()).ToList();


            foreach (var phraseModel in phraseModels)
            {
                await AddCalculatedValuesAsync(phraseModel);
            }

            return phraseModels;
        }

        public async Task<Phrase> CreateAsync(Phrase phrase)
        {
            var entity = phrase.MapToEntity();
            await phraseCommandService.CreateAsync(entity);

            await AddCalculatedValuesAsync(phrase);

            return phrase;
        }

        private async Task<Phrase> AddCalculatedValuesAsync(Phrase model)
        {
            var alphabetEntities = await alphabetQueryService.GetAsync();
            var alphabetModels = alphabetEntities.Select(x => x.MapToModel()).ToList();

            model.NonCyrillicRussian = GetNonCyrillicRussian(model.Russian ?? "", alphabetModels);

            return model;
        }

        private static string GetNonCyrillicRussian(string cyrillicRussianPhrase, List<Alphabet> alphabet)
        {
            var sb = new StringBuilder();
            foreach (var russianChar in cyrillicRussianPhrase)
            {
                // https://en.wikipedia.org/wiki/List_of_Unicode_characters
                // Cyrillic Unicode code point
                if (russianChar >= 1024 && russianChar <= 1279)
                {
                    var item = alphabet.First(x => string.Compare(x.Russian, russianChar.ToString(), ignoreCase: true) != -1);
                    sb.Append(GetCorrectCase(item.English, russianChar));

                    continue;
                }

                sb.Append(russianChar);
            }

            return sb.ToString();
        }

        private static string GetCorrectCase(string value, char russian)
        {
            var sb = new StringBuilder(value.ToLower());
            if (!char.IsLower(russian))
                sb[0] = char.ToUpper(sb[0]);

            return sb.ToString();
        }

    }
}