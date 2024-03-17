namespace EF.Mappers
{
    public static class PhraseMapper
    {
        public static Core.Models.Phrase MapToModel(this Entities.Phrase entity)
        {
            return new Core.Models.Phrase
            {
                English = entity.English,
                Russian = entity.Russian,
                UniqueId = entity.UniqueId,
                Category = entity.Category
            };
        }
    }
}