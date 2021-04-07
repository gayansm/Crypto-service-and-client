using CryptoService.Data;
using CryptoService.Domain;
using CryptoService.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace CryptoService
{
	public class Startup
	{
		private const string CorsPolicy = "EnableAllPolicy";

		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddSingleton<IUser, User>();
			services.AddSingleton<IPriceService, CoinSpotPriceService>();
			services.AddCors(options =>
			{
				options.AddPolicy(CorsPolicy,
					builder =>
					{
						builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
					});
			
			});
			services.AddControllers();
			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new OpenApiInfo { Title = "CryptoService", Version = "v1" });
			});
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IPriceService priceService)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				app.UseSwagger();
				app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CryptoService v1"));
			}

			app.UseCors(CorsPolicy);

			app.UseRouting();

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});

			// This is not the best place or the best way to update the list of valid coins.
			// This resulted from (incorrectly) assuming only three types of coins should be supported
			// during the design stage. Going forward with this now due to time constraints.
			CoinStore.AddCoinsToStore(priceService.GetAllValidCoins().GetAwaiter().GetResult());
		}
	}
}
