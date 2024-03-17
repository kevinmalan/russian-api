using Core.Models;

namespace Core.Mappers
{
    public static class AlphabetMapper
    {
        public static API.Dtos.Alphabet MapToDto(this Alphabet model)
        {
            return new API.Dtos.Alphabet
            {
                UniqueId = model.UniqueId,
                English = model.English,
                Russian = model.Russian,
                Examples = model.Examples?.Split(",")
            };
        }
    }
}