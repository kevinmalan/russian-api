namespace EF.Entities
{
    public class Phrase
    {
        public int Id { get; set; }
        public Guid UniqueId { get; set; }
        public string? Russian { get; set; }
        public string? English { get; set; }
        public string? Category { get; set; }
    }
}