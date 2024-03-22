using Shared.Dtos;

namespace API.Mappers
{
    public static class PhraseMapper
    {
        public static Phrase MapToDto(this Core.Models.Phrase model)
            => new()
            {
                English = model.English,
                Russian = model.Russian,
                UniqueId = model.UniqueId,
                Category = model.Category,
                NonCyrillicRussian = model.NonCyrillicRussian
            };

        public static Core.Models.Phrase MapToModel(this Phrase dto)
            => new()
            {
                English = dto.English,
                Russian = dto.Russian,
                UniqueId = dto.UniqueId,
                Category = dto.Category
            };
    }
}