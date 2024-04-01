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
        private ChallengeLocalState _challengeLocalState { get; set; }

        protected override async Task OnInitializedAsync()
        {
            if (AlphabetState.Value.Alphabet.Count == 0)
            {
                Dispatcher.Dispatch(new GetAlphabetAction());

                AlphabetState.StateChanged += HandleAlphabetStateChanged;
            }
            else if (string.IsNullOrWhiteSpace(_challengeLocalState.ChallengeText))
            {
                UpdateChallengeText();
            }
        }

        private void HandleAlphabetStateChanged(object sender, object e)
        {
            UpdateChallengeText();
            StateHasChanged();
        }

        private void HandleKeyPress(KeyboardEventArgs e)
        {
            if (e.Key == "Enter")
            {
                if (!string.IsNullOrWhiteSpace(_challengeLocalState.Message))
                    NextClicked();
                else
                    GoClicked();
            }
        }

        private void GoClicked()
        {
            var challengeText = _challengeLocalState.ChallengeText;
            var challengeEnglish = AlphabetState.Value.Alphabet.First(x => x.Russian == challengeText).English;
            var challengeInputValie = _challengeLocalState.ChallengeInputValue;
            var isCorrect = string.Equals(challengeEnglish, challengeInputValie, StringComparison.OrdinalIgnoreCase);
            _challengeLocalState.Verdict = isCorrect;
            _challengeLocalState.Message = $"{challengeText} : {challengeEnglish}";
        }

        private void NextClicked()
        {
            _challengeLocalState.Verdict = null;
            _challengeLocalState.Message = string.Empty;
            UpdateChallengeText();
        }

        private void UpdateChallengeText()
        {
            // TODO: TryDequeue. If empty, display final score. Reset will requeue alphabet
            var dequeue = AlphabetState.Value.AlphabetQueue.Dequeue();
            _challengeLocalState.ChallengeText = dequeue.Russian;
            _challengeLocalState.ChallengeInputValue = string.Empty;
        }
    }
}