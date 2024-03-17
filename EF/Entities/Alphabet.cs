namespace EF.Entities
{
    public class Alphabet
    {
        public int Id { get; set; }
        public Guid UniqueId { get; set; }
        public required string Russian { get; set; }
        public required string English { get; set; }
        public string? Examples { get; set; }
    }
}