using CryptoService.Data;
using CryptoService.Shared;
using CryptoService.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CryptoService.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class MarketDataController : Controller
	{
		private IPriceService priceService;

		public MarketDataController(IPriceService priceService)
		{
			this.priceService = priceService;
		}

		[HttpGet]
		[Route("{symbol}")]
		public async Task<IActionResult> GetCoinData(string symbol)
		{
			if (string.IsNullOrEmpty(symbol) ||
				!CoinStore.IsSymbolValid(symbol) ||
				!CoinStore.GetCoin(symbol, out Coin coin))
				return BadRequest();

			var coinData = await priceService.GetCoinData(coin);
			coin.UpdatePrices(coinData.SpotRate, coinData.Ask, coinData.Bid);
			return Ok(coin);
		}
	}
}
