namespace UI.State.Alphabet.Actions
{
    public class GetAlphabetResultAction(List<Shared.Dtos.Alphabet> alphabet)
    {
        public List<Shared.Dtos.Alphabet> Alphabet { get; set; } = alphabet;
    }
}