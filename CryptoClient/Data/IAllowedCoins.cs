using System.Collections.Generic;

namespace CryptoClient.Data
{
	public interface IAllowedCoins
	{
		List<string> GetAllowedCoins();
	}
}
