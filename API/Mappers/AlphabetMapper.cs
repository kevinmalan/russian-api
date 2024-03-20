using Shared.Dtos;

namespace API.Mappers
{
    public static class AlphabetMapper
    {
        public static Alphabet MapToDto(this Core.Models.Alphabet model)
        {
            return new Alphabet
            {
                UniqueId = model.UniqueId,
                English = model.English,
                Russian = model.Russian,
                Examples = model.Examples
            };
        }
    }
}
