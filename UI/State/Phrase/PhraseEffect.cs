using Fluxor;
using UI.Services.Contracts;
using UI.State.Phrase.Actions;

namespace UI.State.Phrase
{
    public class PhraseEffect(IApiService apiService)
    {
        [EffectMethod(typeof(GetPhrasesAction))]
        public async Task HandGetPhrasesAction(IDispatcher dispatcher)
        {
            var phrases = await apiService.GetPhrasesAsync();
            dispatcher.Dispatch(new GetPhrasesResultAction(phrases));
        }

        [EffectMethod]
        public async Task HandleAddPhraseAction(AddPhraseAction action, IDispatcher dispatcher)
        {
            var response = await apiService.CreatePhraseAsync(new Shared.Dtos.Phrase
            {
                Russian = action.RussianValue,
                English = action.EnglishValue,
                Category = action.CategoryValue,
                UniqueId = Guid.NewGuid()
            });

            var resultAction = new AddPhraseResultAction
            {
                Phrase = response
            };

            dispatcher.Dispatch(resultAction);
        }
    }
}