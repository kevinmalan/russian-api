using Core.Models;

namespace Core.Mappers
{
    public static class AlphabetMapper
    {
        public static Alphabet MapToModel(this EF.Entities.Alphabet entity)
        {
            return new Alphabet
            {
                UniqueId = entity.UniqueId,
                English = entity.English,
                Russian = entity.Russian,
                Examples = entity.Examples
            };
        }
    }
}