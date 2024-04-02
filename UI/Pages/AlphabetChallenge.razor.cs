using Fluxor;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using UI.State.Alphabet;
using UI.State.Alphabet.Actions;
using UI.State.Alphabet.Local;

namespace UI.Pages
{
    public partial class AlphabetChallenge
    {
        [Inject]
        private IState<AlphabetState> AlphabetState { get; set; }

        [Inject]
        private IDispatcher Dispatcher { get; set; }

        [Inject]
        private ChallengeLocalState ChallengeLocalState { get; set; }



        protected override async Task OnInitializedAsync()
        {
            if (AlphabetState.Value.Alphabet.Count == 0)
            {
                Dispatcher.Dispatch(new GetAlphabetAction());

                AlphabetState.StateChanged += HandleAlphabetStateChanged;
                return;
            }

            if (string.IsNullOrWhiteSpace(ChallengeLocalState.ChallengeText))
            {
                UpdateChallengeText();
            }
        }

        private void HandleAlphabetStateChanged(object sender, object e)
        {
            UpdateChallengeText();
            ChallengeLocalState.IsChallengeInProgress = true;
            ChallengeLocalState.IsGoDisabled = false;
            StateHasChanged();
        }

        private void HandleKeyPress(KeyboardEventArgs e)
        {
            if (e.Key == "Enter")
            {
                if (!string.IsNullOrWhiteSpace(ChallengeLocalState.Message))
                    NextClicked();
                else
                    GoClicked();
            }
        }

        private void GoClicked()
        {
            ChallengeLocalState.IsGoDisabled = true;
            ChallengeLocalState.IsNextDisabled = false;
            var challengeText = ChallengeLocalState.ChallengeText;
            var challengeEnglish = AlphabetState.Value.Alphabet.First(x => x.Russian == challengeText).English;
            var challengeInputValie = ChallengeLocalState.ChallengeInputValue;
            var isCorrect = string.Equals(challengeEnglish, challengeInputValie, StringComparison.OrdinalIgnoreCase);
            ChallengeLocalState.Verdict = isCorrect;
            ChallengeLocalState.Message = $"{challengeText} : {challengeEnglish}";
            UpdateScore(isCorrect);
        }

        private void UpdateScore(bool isCorrect)
        {
            var key = isCorrect ? "Correct" : "Incorrect";
            ChallengeLocalState.Score[key]++;
        }

        private void NextClicked()
        {
            ChallengeLocalState.IsGoDisabled = false;
            ChallengeLocalState.IsNextDisabled = true;
            ChallengeLocalState.Verdict = null;
            ChallengeLocalState.Message = string.Empty;
            UpdateChallengeText();
        }

        private void ResetClicked()
        {
            ChallengeLocalState.Verdict = null;
            ChallengeLocalState.Message = string.Empty;
            ChallengeLocalState.ChallengeInputValue = string.Empty;
            ResetScore();
            Dispatcher.Dispatch(new GetAlphabetAction());
        }

        private void UpdateChallengeText()
        {
            var canDequeue = AlphabetState.Value.AlphabetQueue.TryDequeue(out var item);
            if (!canDequeue)
            {
                CalculateResults();
                return;
            }
            ChallengeLocalState.ChallengeText = item.Russian;
            ChallengeLocalState.ChallengeInputValue = string.Empty;
        }

        private void CalculateResults()
        {
            ChallengeLocalState.Verdict = null;
            ChallengeLocalState.Message = $"Challenge Completed. Correct: '{ChallengeLocalState.Score["Correct"]}' Incorrect: '{ChallengeLocalState.Score["Incorrect"]}'";
            ChallengeLocalState.ChallengeInputValue = string.Empty;
            ChallengeLocalState.IsChallengeInProgress = false;
            ChallengeLocalState.IsGoDisabled = true;
            ChallengeLocalState.IsNextDisabled = true;
            ResetScore();
        }

        private void ResetScore()
        {
            ChallengeLocalState.Score["Correct"] = 0;
            ChallengeLocalState.Score["Incorrect"] = 0;
        }
    }
}