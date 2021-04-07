using System;
using System.Net.Http;

namespace CryptoClient.Services
{
	public class TestPreferenceAndPriceService
	{
		#region Fields

		private const string CoinServiceUriBase = @"https://localhost:5000/";
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

		public void SetUserPreferredCoin(string symbol)
		{
			var response = connection.PostAsync(UserPreferenceServicePath, new StringContent(symbol)).Result;
		}

		#endregion
	}
}
