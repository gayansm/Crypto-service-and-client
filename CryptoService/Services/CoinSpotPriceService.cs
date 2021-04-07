using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using CryptoService.Shared;
using Newtonsoft.Json;

namespace CryptoService.Services
{
	public class CoinSpotPriceService : IPriceService
	{
		#region Fields

		private const string CoinServiceUriBase = @"https://trade.cointree.com/api/prices/aud/";
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

		public async Task<CoinData> GetCoinData(Coin coin)
		{
			if (!initialized)
				SetupConnection();

			var response = await connection.GetStringAsync(coin.Symbol);
			var instance = JsonConvert.DeserializeObject<CoinData>(response);
			return instance;
		}

		public async Task<IEnumerable<Tuple<string, Coin>>> GetAllValidCoins()
		{
			if (!initialized)
				SetupConnection();

			var response = await connection.GetStringAsync(string.Empty);
			var allCoinData = JsonConvert.DeserializeObject<List<CoinData>>(response);
			return allCoinData.Select(coinData =>
			{
				var symbol = coinData.Buy.ToUpper();
				return new Tuple<string, Coin>(symbol, new Coin(symbol, symbol));
			});

		}

		#endregion
	}
}
