namespace EF.Mappers
{
    public static class AlphabetMapper
    {
        public static Core.Models.Alphabet MapToModel(this Entities.Alphabet entity)
        {
            return new Core.Models.Alphabet
            {
                UniqueId = entity.UniqueId,
                English = entity.English,
                Russian = entity.Russian,
                Examples = entity.Examples
            };
        }
    }
}