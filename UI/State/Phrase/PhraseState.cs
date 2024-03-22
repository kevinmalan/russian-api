using Fluxor;

namespace UI.State.Phrase
{
    [FeatureState]
    public class PhraseState
    {
        public PhraseState()
        { 
        }

        public List<Shared.Dtos.Phrase> Phrases { get; set; } = [];
    }
}