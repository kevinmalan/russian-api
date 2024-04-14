using Fluxor;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using UI.State.Alphabet;
using UI.State.Alphabet.Actions;
using UI.State.Alphabet.Local;
using UI.State.Phrase;
using UI.State.Phrase.Actions;

namespace UI.Pages
{
    public partial class PhraseChallenge
    {
        [Inject]
        private IState<PhraseState> PhraseState { get; set; }

        [Inject]
        private IState<PhraseChallengeState> PhraseChallengeState { get; set; }

        [Inject]
        private IDispatcher Dispatcher { get; set; }

        protected override async Task OnInitializedAsync()
        {
            if (PhraseState.Value.Phrases.Count == 0)
            {
                Dispatcher.Dispatch(new GetPhrasesAction());

                PhraseState.StateChanged += HandlePhraseStateChanged;
            }
            else if (!PhraseChallengeState.Value.IsChallengeInProgress)
            {
                BuildChallenge();
            }
        }

        private void HandlePhraseStateChanged(object sender, object e)
            => BuildChallenge();

        private void BuildChallenge()
        {
            UpdateChallengeText();
            StateHasChanged();

            Dispatcher.Dispatch(new UpdatePhraseChallengeAction
            {
                Changed = [
                    nameof(UpdatePhraseChallengeAction.IsChallengeInProgress),
                    nameof(UpdatePhraseChallengeAction.IsGoDisabled)
                ],
                IsChallengeInProgress = true,
                IsGoDisabled = false
            });
        }

        private void HandleKeyPress(KeyboardEventArgs e)
        {
            if (e.Key == "Enter")
            {
                if (!string.IsNullOrWhiteSpace(PhraseChallengeState.Value.Message))
                    NextClicked();
                else
                    GoClicked();
            }
        }

        private void GoClicked()
        {
            var challengeText = PhraseChallengeState.Value.ChallengeText;
            var challengeEnglish = PhraseState.Value.Phrases.First(x => x.Russian == challengeText).English;
            var challengeInputValie = PhraseChallengeState.Value.ChallengeInputValue;
            var isCorrect = string.Equals(challengeEnglish, challengeInputValie, StringComparison.OrdinalIgnoreCase);

            Dispatcher.Dispatch(new UpdatePhraseChallengeAction
            {
                Changed = [
                    nameof(UpdatePhraseChallengeAction.IsGoDisabled),
                    nameof(UpdatePhraseChallengeAction.IsNextDisabled),
                    nameof(UpdatePhraseChallengeAction.Verdict),
                    nameof(UpdatePhraseChallengeAction.Message)
                ],
                IsGoDisabled = true,
                IsNextDisabled = false,
                Verdict = isCorrect,
                Message = $"{challengeText} : {challengeEnglish}"
            });

            UpdateScore(isCorrect);
        }

        private void UpdateScore(bool isCorrect)
        {
            Dispatcher.Dispatch(new UpdatePhraseChallengeAction
            {
                IncrementScore = isCorrect,
                DecrementScore = !isCorrect
            });
        }

        private void NextClicked()
        {
            Dispatcher.Dispatch(new UpdatePhraseChallengeAction
            {
                Changed = [
                    nameof(UpdatePhraseChallengeAction.IsNextDisabled),
                    nameof(UpdatePhraseChallengeAction.IsGoDisabled),
                    nameof(UpdatePhraseChallengeAction.Verdict),
                    nameof(UpdatePhraseChallengeAction.Message)
                ],
                IsGoDisabled = false,
                IsNextDisabled = true,
                Verdict = null,
                Message = string.Empty
            });
            UpdateChallengeText();
        }

        private void ResetClicked()
        {
            Dispatcher.Dispatch(new UpdatePhraseChallengeAction
            {
                Changed = [
                    nameof(UpdatePhraseChallengeAction.Verdict),
                    nameof(UpdatePhraseChallengeAction.Message),
                    nameof(UpdatePhraseChallengeAction.ChallengeInputValue)
                ],
                Verdict = null,
                Message = string.Empty,
                ChallengeInputValue = string.Empty
            });
            ResetScore();
            Dispatcher.Dispatch(new GetPhrasesAction());
        }

        private void UpdateChallengeText()
        {
            var canDequeue = PhraseState.Value.PhraseQueue.TryDequeue(out var item);
            if (!canDequeue)
            {
                CalculateResutls();
                return;
            }

            Dispatcher.Dispatch(new UpdatePhraseChallengeAction
            {
                Changed = [nameof(UpdatePhraseChallengeAction.ChallengeText), nameof(UpdatePhraseChallengeAction.ChallengeInputValue)],
                ChallengeText = item.Russian,
                ChallengeInputValue = string.Empty
            });
        }

        private void CalculateResutls()
        {
            Dispatcher.Dispatch(new UpdatePhraseChallengeAction
            {
                Changed = [
                    nameof(UpdatePhraseChallengeAction.Verdict),
                    nameof(UpdatePhraseChallengeAction.Message),
                    nameof(UpdatePhraseChallengeAction.ChallengeInputValue),
                    nameof(UpdatePhraseChallengeAction.IsChallengeInProgress),
                    nameof(UpdatePhraseChallengeAction.IsGoDisabled),
                    nameof(UpdatePhraseChallengeAction.IsNextDisabled)
                    ],
                Verdict = null,
                Message = $"Challenge Completed. Correct: '{PhraseChallengeState.Value.Score["Correct"]}' Incorrect: '{PhraseChallengeState.Value.Score["Incorrect"]}'",
                ChallengeInputValue = string.Empty,
                IsChallengeInProgress = false,
                IsGoDisabled = true,
                IsNextDisabled = true,
            });

            ResetScore();
        }

        private void ResetScore()
        {
            Dispatcher.Dispatch(new UpdatePhraseChallengeAction
            {
                ResetScore = true
            });
        }
    }
}