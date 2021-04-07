using CryptoService.Shared;

namespace CryptoService.Domain
{
	public interface IUser
	{
		Coin PreferredCoin {get;}
		bool SetPreferredCoin(string symbol);
	}
}
