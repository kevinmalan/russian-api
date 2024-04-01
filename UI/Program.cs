using Fluxor;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using UI.Services;
using UI.Services.Contracts;
using UI.State.Alphabet.Local;

namespace UI
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddScoped<IApiService, ApiService>();
            builder.Services.AddFluxor(o => o
             .ScanAssemblies(typeof(Program).Assembly));

            // Local State
            builder.Services.AddSingleton<ChallengeLocalState>();

            await builder.Build().RunAsync();
        }
    }
}
