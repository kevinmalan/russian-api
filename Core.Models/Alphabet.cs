namespace Core.Models
{
    public class Alphabet
    {
        public Guid UniqueId { get; set; }
        public required string Russian { get; set; }
        public required string English { get; set; }
        public string? Examples { get; set; }
    }
}