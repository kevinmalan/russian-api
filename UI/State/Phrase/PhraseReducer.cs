using Fluxor;

namespace UI.State.Phrase
{
    public static class PhraseReducer
    {
        [ReducerMethod]
        public static PhraseState ReduceAddPhraseAction(PhraseState state, AddPhraseAction action)
        {
            if (action?.Phrase != null)
                state.Phrases.Add(action.Phrase);

            return state;
        }
    }
}