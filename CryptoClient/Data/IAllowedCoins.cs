using System.Collections.Generic;
using System.Threading.Tasks;

namespace CryptoClient.Data
{
	public interface IAllowedCoins
	{
		Task<List<string>> GetAllowedCoins();
	}
}
