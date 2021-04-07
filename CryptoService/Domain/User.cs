using CryptoService.Data;
using CryptoService.Shared;

namespace CryptoService.Domain
{
	public class User : IUser
	{
		#region Properties

		public Coin PreferredCoin { get; private set; }

		#endregion

		#region Methods

		public bool SetPreferredCoin(string symbol)
		{
			if (CoinStore.GetCoin(symbol, out Coin coin))
			{
				PreferredCoin = coin;
				return true;
			}

			return false;
		}

		#endregion
	}
}
