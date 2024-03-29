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
    }
}
