using CryptoService.Shared;
using System.Threading.Tasks;

namespace CryptoClient.Services
{
	public interface IPreferenceAndPriceService
	{
		Task<bool> SetUserPreferredCoin(string symbol);
		Task<Coin> GetCoinPriceData(string symbol);
	}
}
