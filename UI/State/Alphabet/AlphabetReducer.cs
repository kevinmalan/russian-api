using Fluxor;
using UI.State.Alphabet.Actions;

namespace UI.State.Alphabet
{
    public class AlphabetReducer
    {
        [ReducerMethod]
        public static AlphabetState ReduceGetAlphabetResultAction(AlphabetState state, GetAlphabetResultAction action)
        => new()
        {
            Alphabet = action.Alphabet
        };
    }
}