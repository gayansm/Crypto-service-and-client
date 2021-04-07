using System.Linq;
using System.Collections.Generic;
using System;
using CryptoService.Shared;

namespace CryptoService.Data
{
	public static class CoinStore
	{
		#region Fields

		private static Dictionary<string, Coin> Coins = new Dictionary<string, Coin>
		{
			{ "BTC", new Coin("BTC", "Bitcoin")},
			{ "ETH", new Coin("ETH", "Ethereum")},
			{ "XRP", new Coin("XRP", "Ripple")}
		};

		#endregion

		#region Methods

		public static bool GetCoin(string symbol, out Coin coin)
		{
			return Coins.TryGetValue(symbol.ToUpper(), out coin);
		}

		public static bool IsSymbolValid(string symbol)
		{
			return Coins.Keys.Contains(symbol.ToUpper());
		}

		/// <summary>
		/// To support all coins if required.
		/// </summary>
		/// <param name="coinsToAdd">A collection of <see cref="Coin"/>s to add to the main store.</param>
		public static void AddCoinsToStore(IEnumerable<Tuple<string, Coin>> coinsToAdd)
		{
			foreach (var kv in coinsToAdd)
				if (!Coins.ContainsKey(kv.Item1))
					Coins.Add(kv.Item1, kv.Item2);
		}

		#endregion
	}
}
