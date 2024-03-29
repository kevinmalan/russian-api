using Fluxor;
using Microsoft.AspNetCore.Components;
using UI.State.Alphabet;
using UI.State.Alphabet.Actions;

namespace UI.Pages
{
    public partial class Alphabet
    {
        [Inject]
        private IState<AlphabetState> AlphabetState { get; set; }

        [Inject]
        private IDispatcher Dispatcher { get; set; }

        protected override async Task OnInitializedAsync()
        {
            if (AlphabetState.Value.Alphabet.Count == 0)
                Dispatcher.Dispatch(new GetAlphabetAction());
        }
    }
}