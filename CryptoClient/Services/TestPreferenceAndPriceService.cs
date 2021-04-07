using CryptoService.Shared;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace CryptoClient.Services
{
	public class TestPreferenceAndPriceService : IPreferenceAndPriceService
	{
		#region Fields

		private const string CoinServiceUriBase = @"http://localhost:5000/";
		private const string MarketDataServicePath = "marketdata";
		private const string UserPreferenceServicePath = "user/preferred";
		private HttpClient connection;
		private bool initialized;

		#endregion

		#region Methods

		public void SetupConnection()
		{
			if (initialized)
				return;

			connection = new HttpClient();
			connection.BaseAddress = new Uri(CoinServiceUriBase);
			initialized = true;
		}

		public async Task<bool> SetUserPreferredCoin(string symbol)
		{
			if (!initialized)
				SetupConnection();

			var content = new StringContent(string.Empty);
			var response = await connection.PostAsync($"{UserPreferenceServicePath}?symbol={symbol}", content);
			return response.StatusCode == System.Net.HttpStatusCode.OK;
		}

		public async Task<Coin> GetCoinPriceData(string symbol)
		{
			if (!initialized)
				SetupConnection();

			var response = await connection.GetStringAsync($"{MarketDataServicePath}/{symbol}");
			var coin =  JsonConvert.DeserializeObject<Coin>(response);
			return coin;
		}

		#endregion
	}
}
