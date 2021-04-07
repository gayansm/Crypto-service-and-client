using CryptoService.Shared;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CryptoService.Services
{
	public interface IPriceService
	{
		void SetupConnection();

		Task<CoinData> GetCoinData(Coin coin);

		Task<IEnumerable<Tuple<string, Coin>>> GetAllValidCoins();
	}
}
