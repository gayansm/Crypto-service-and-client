using System.Collections.Generic;

namespace CryptoClient.Data
{
	public class AllowedCoins : IAllowedCoins
	{
		private List<string> coins = new List<string>
		{
			"BTC", "ETH", "XRP"
		};

		public List<string> GetAllowedCoins()
		{
			return coins;
		}
	}
}
