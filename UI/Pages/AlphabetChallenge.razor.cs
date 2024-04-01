using Fluxor;
using Microsoft.AspNetCore.Components;
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

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (!firstRender)
                return;

            if (AlphabetState.Value.Alphabet.Count == 0)
            {
                Dispatcher.Dispatch(new GetAlphabetAction());

                AlphabetState.StateChanged += HandleAlphabetStateChanged;
            }
        }

        private void HandleAlphabetStateChanged(object sender, object e)
        {
            UpdateChallengeText();
            StateHasChanged();
        }

        public void GoClicked()
        {
            UpdateChallengeText();
            var value = _challengeLocalState.ChallengeInputValue;
            // TODO assert input with actual result
        }

        private void UpdateChallengeText()
        {
            // TODO: TryDequeue. If empty, display final score. Reset will requeue alphabet
            var dequeue = AlphabetState.Value.AlphabetQueue.Dequeue();
            _challengeLocalState.ChallengeText = dequeue.Russian;
        }
    }
}