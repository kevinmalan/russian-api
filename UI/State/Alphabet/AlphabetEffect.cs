using Fluxor;
using UI.Services.Contracts;
using UI.State.Alphabet.Actions;

namespace UI.State.Alphabet
{
    public class AlphabetEffect(IApiService apiService)
    {
        [EffectMethod(typeof(GetAlphabetAction))]
        public async Task HandleGetAlphabetAction(IDispatcher dispatcher)
        {
            var alphabet = await apiService.GetAlphabetAsync();
            dispatcher.Dispatch(new GetAlphabetResultAction(alphabet));
        }
    }
}
