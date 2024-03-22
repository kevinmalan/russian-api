using Fluxor;
using Microsoft.AspNetCore.Components;
using UI.State.Phrase;

namespace UI.Pages
{
    public partial class Phrases
    {
        private string russianValue = "";
        private string englishValue = "";
        private string catergoryValue = "Common";

        [Inject]
        private IState<PhraseState> PhraseState { get; set; }

        [Inject]
        public IDispatcher Dispatcher { get; set; }

        protected override async Task OnInitializedAsync()
        {
            if (PhraseState.Value.Phrases.Count == 0)
                PhraseState.Value.Phrases = await ApiService.GetPhrasesAsync();
        }

        private async Task AddAsync()
        {
            if (!IsInputValid())
                return;

            var response = await ApiService.CreatePhraseAsync(new Shared.Dtos.Phrase
            {
                Russian = russianValue,
                English = englishValue,
                Category = catergoryValue,
                UniqueId = Guid.NewGuid()
            });

            var action = new AddPhraseAction
            {
                Phrase = response
            };

            Dispatcher.Dispatch(action);

            ResetInputValues();
        }

        private bool IsInputValid()
        {
            // TODO: Ensure russianValue is legit Cyrillic text
            return
                !string.IsNullOrWhiteSpace(russianValue) &&
                !string.IsNullOrWhiteSpace(englishValue) &&
                !string.IsNullOrWhiteSpace(catergoryValue);
        }

        private void ResetInputValues()
        {
            russianValue = "";
            englishValue = "";
            catergoryValue = "Common";
        }
    }
}
