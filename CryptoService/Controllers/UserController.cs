using Microsoft.AspNetCore.Mvc;
using CryptoService.Data;
using CryptoService.Domain;
using System.Net;

namespace CryptoService.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class UserController : ControllerBase
	{
		private readonly IUser user;

		public UserController(IUser user)
		{
			this.user = user;
		}

		[HttpPost]
		[Route("preferred")]
		public IActionResult SetPreferredCoin(string symbol)
		{
			if (!CoinStore.IsSymbolValid(symbol) ||
				!user.SetPreferredCoin(symbol))
				return BadRequest();

			return Ok();
		}
	}
}
