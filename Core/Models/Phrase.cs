namespace Core.Models
{
    public class Phrase
    {
        public Guid UniqueId { get; set; }
        public string? Russian { get; set; }
        public string? NonCyrillicRussian { get; set; }
        public string? English { get; set; }
        public string? Category { get; set; }
    }
}
