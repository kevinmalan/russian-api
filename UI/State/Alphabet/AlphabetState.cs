using Fluxor;

namespace UI.State.Alphabet
{
    [FeatureState]
    public class AlphabetState
    {
        public AlphabetState()
        {
        }

        public List<Shared.Dtos.Alphabet> Alphabet { get; set; } = [];
        public Queue<Shared.Dtos.Alphabet> AlphabetQueue { get; set; } = new();
    }
}
