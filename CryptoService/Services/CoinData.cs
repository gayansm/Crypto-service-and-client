using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoService.Services
{
	public class CoinData
	{
		public string Sell { get; set; }
		public string Buy { get; set; }
		public double Ask { get; set; }
		public double Bid { get; set; }
		public double Rate { get; set; }
		public double SpotRate { get; set; }
		public string Market { get; set; }
		public string Timestamp { get; set; }
		public string RateType { get; set; }
		public object RateSteps { get; set; }
	}
}
