
namespace CryptoService.Shared
{
	public class Coin
	{
		#region Properties

		public string Symbol { get; private set; }
		public string Name { get; private set; }
		public double Rate { get; private set; }
		public virtual double Ask { get; protected set; }
		public double Bid { get; private set; }

		#endregion

		#region Methods

		public Coin(string symbol, string name, double rate = 0, double ask = 0, double bid = 0)
		{
			Symbol = symbol;
			Name = name;
			UpdatePrices(rate, ask, bid);
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
