using Core.Models;

namespace Core.Mappers
{
    public static class PhraseMapper
    {
        public static Phrase MapToModel(this EF.Entities.Phrase entity)
        {
            return new Phrase
            {
                English = entity.English,
                Russian = entity.Russian,
                UniqueId = entity.UniqueId,
                Category = entity.Category
            };
        }
    }
}