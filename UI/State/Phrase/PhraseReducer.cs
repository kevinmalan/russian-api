using Fluxor;
using UI.State.Phrase.Actions;

namespace UI.State.Phrase
{
    public static class PhraseReducer
    {
        [ReducerMethod]
        public static PhraseState ReduceAddPhraseResultAction(PhraseState state, AddPhraseResultAction action)
        {
            state.Phrases.Add(action.Phrase);

            return new PhraseState
            {
                Phrases = state.Phrases
            };
        }

        [ReducerMethod]
        public static PhraseState ReduceGetPhrasesResultAction(PhraseState state, GetPhrasesResultAction action)
         => new()
         {
             Phrases = action.Phrases
         };
    }
}