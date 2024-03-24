namespace UI.State.Phrase.Actions
{
    public class GetPhrasesResultAction(List<Shared.Dtos.Phrase> phrases)
    {
        public List<Shared.Dtos.Phrase> Phrases { get; set; } = phrases;
    }
}