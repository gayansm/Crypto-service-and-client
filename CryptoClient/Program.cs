using CryptoClient.Data;
using CryptoClient.Services;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace CryptoClient
{
	public class Program
	{
		public static async Task Main(string[] args)
		{
			var builder = WebAssemblyHostBuilder.CreateDefault(args);
			builder.RootComponents.Add<App>("#app");

			builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
			builder.Services.AddSingleton<IPreferenceAndPriceService>(priceService => new TestPreferenceAndPriceService());
			builder.Services.AddSingleton<IAllowedCoins>(allowedCoins => new AllowedCoins());

			await builder.Build().RunAsync();
		}
	}
}
