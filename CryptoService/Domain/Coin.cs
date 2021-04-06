
namespace CryptoService.Domain
{
	public class Coin
	{
		#region Properties

		public string Symbol { get; private set; }
		public string Name { get; private set; }
		public double Rate { get; private set; }
		public double Ask { get; private set; }
		public double Bid { get; private set; }

		#endregion

		#region Methods

		public Coin(string symbol, string name)
		{
			Symbol = symbol;
			Name = name;
		}

		public void UpdatePrices(double rate, double ask, double bid)
		{
			Rate = rate;
			Ask = ask;
			Bid = bid;
		}

		#endregion
	}
}
