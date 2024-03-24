using Fluxor;

namespace UI.State.Phrase
{
    [FeatureState]
    public record PhraseState
    {
        public PhraseState()
        { 
        }

        public List<Shared.Dtos.Phrase> Phrases { get; set; } = [];
    }
}