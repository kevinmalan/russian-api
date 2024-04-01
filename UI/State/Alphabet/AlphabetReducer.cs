using Fluxor;
using UI.State.Alphabet.Actions;

namespace UI.State.Alphabet
{
    public class AlphabetReducer
    {
        [ReducerMethod]
        public static AlphabetState ReduceGetAlphabetResultAction(AlphabetState state, GetAlphabetResultAction action)
        {
            var queue = new Queue<Shared.Dtos.Alphabet>();
            action.Alphabet.ForEach(x => queue.Enqueue(x));
            return new AlphabetState
            {
                Alphabet = action.Alphabet,
                AlphabetQueue = queue
            };
        }
    }
}