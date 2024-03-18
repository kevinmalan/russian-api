using API.Dtos;

namespace API.Mappers
{
    public static class PhraseMapper
    {
        public static Phrase MapToDto(this Core.Models.Phrase models)
        {
            return new Phrase
            {
                English = models.English,
                Russian = models.Russian,
                UniqueId = models.UniqueId,
                Category = models.Category,
                NonCyrillicRussian = models.NonCyrillicRussian
            };
        }
    }
}
