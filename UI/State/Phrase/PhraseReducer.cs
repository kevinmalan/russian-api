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
        {
            var queue = new Queue<Shared.Dtos.Phrase>();
            action.Phrases.ForEach(x => queue.Enqueue(x));
            return new PhraseState
            {
                Phrases = action.Phrases,
                PhraseQueue = queue
            };
        }

        [ReducerMethod]
        public static PhraseChallengeState ReduceUpdatePhraseChallengeAction(PhraseChallengeState state, UpdatePhraseChallengeAction action)
        {
            if (action.Changed != null && action.Changed.Count > 0)
            {
                if (action.Changed.Contains(nameof(UpdatePhraseChallengeAction.ChallengeText)))
                    state.ChallengeText = action.ChallengeText;

                if (action.Changed.Contains(nameof(UpdatePhraseChallengeAction.ChallengeInputValue)))
                    state.ChallengeInputValue = action.ChallengeInputValue;

                if (action.Changed.Contains(nameof(UpdatePhraseChallengeAction.Verdict)))
                    state.Verdict = action.Verdict;

                if (action.Changed.Contains(nameof(UpdatePhraseChallengeAction.Message)))
                    state.Message = action.Message;

                if (action.Changed.Contains(nameof(UpdatePhraseChallengeAction.IsChallengeInProgress)))
                    state.IsChallengeInProgress = action.IsChallengeInProgress;

                if (action.Changed.Contains(nameof(UpdatePhraseChallengeAction.IsGoDisabled)))
                    state.IsGoDisabled = action.IsGoDisabled;

                if (action.Changed.Contains(nameof(UpdatePhraseChallengeAction.IsNextDisabled)))
                    state.IsNextDisabled = action.IsNextDisabled;
            }

            if (action.IncrementScore)
                state.Score["Correct"]++;

            if (action.DecrementScore)
                state.Score["Incorrect"]++;

            if (action.ResetScore)
                state.Score = new()
                {
                    {"Correct", 0 },
                    {"Incorrect", 0 }
                };

            return new PhraseChallengeState
            {
                ChallengeText = state.ChallengeText,
                ChallengeInputValue = state.ChallengeInputValue,
                Verdict = state.Verdict,
                Message = state.Message,
                IsChallengeInProgress = state.IsChallengeInProgress,
                IsGoDisabled = state.IsGoDisabled,
                IsNextDisabled = state.IsNextDisabled,
                Score = state.Score,
            };
        }
    }
}