using System.Collections.Generic;
using System.Threading.Tasks;

namespace CryptoClient.Data
{
	public class AllowedCoins : IAllowedCoins
	{
		private List<string> coins = new List<string>
		{
			"BTC", "ETH", "XRP"
		};

		public async Task<List<string>> GetAllowedCoins()
		{
			// Pseudo async implementation to emulate real-world scenarios.
			return await Task.FromResult(coins);
		}
	}
}
