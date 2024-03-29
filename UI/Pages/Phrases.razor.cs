using Fluxor;
using Microsoft.AspNetCore.Components;
using UI.State.Phrase;
using UI.State.Phrase.Actions;

namespace UI.Pages
{
    public partial class Phrases
    {
        private string _russianValue = "";
        private string _englishValue = "";
        private string _catergoryValue = "Common";

        [Inject]
        private IState<PhraseState>? PhraseState { get; set; }

        [Inject]
        private IDispatcher Dispatcher { get; set; }

        protected override async Task OnInitializedAsync()
        {
            if (PhraseState.Value.Phrases.Count == 0)
                Dispatcher.Dispatch(new GetPhrasesAction());
        }

        private void Add()
        {
            if (!IsInputValid())
                return;

            Dispatcher.Dispatch(new AddPhraseAction
            {
                RussianValue = _russianValue,
                EnglishValue = _englishValue,
                CategoryValue = _catergoryValue
            });

            ResetInputValues();
        }

        private bool IsInputValid()
        {
            // TODO: Ensure russianValue is legit Cyrillic text
            return
                !string.IsNullOrWhiteSpace(_russianValue) &&
                !string.IsNullOrWhiteSpace(_englishValue) &&
                !string.IsNullOrWhiteSpace(_catergoryValue);
        }

        private void ResetInputValues()
        {
            _russianValue = "";
            _englishValue = "";
            _catergoryValue = "Common";
        }
    }
}
