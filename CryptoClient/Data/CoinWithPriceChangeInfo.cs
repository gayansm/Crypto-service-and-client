using CryptoService.Shared;

namespace CryptoClient.Data
{
	public class CoinWithPriceChangeInfo : Coin
	{
		private double ask;

		public override double Ask
		{
			get { return ask; }
			protected set
			{
				var updateValues = PreviousAskPrice == 0 || ask != value;
				if (updateValues) PreviousAskPrice = ask;
				ask = value;
				if (updateValues) UpdateAskPricePercentageChange();				
			}
		}

		public double PreviousAskPrice { get; private set; }

		public double AskPricePercentageChange { get; private set; }

		public CoinWithPriceChangeInfo(string symbol, string name) : base(symbol, name) { }

		public CoinWithPriceChangeInfo(Coin baseTypeCoin) : 
			base(baseTypeCoin.Symbol, 
				baseTypeCoin.Name,
				baseTypeCoin.Ask,
				baseTypeCoin.Bid,
				baseTypeCoin.Rate)
		{			
		}

		private void UpdateAskPricePercentageChange()
		{
			if (PreviousAskPrice == 0)
				return;

			AskPricePercentageChange = ((Ask - PreviousAskPrice) * 100) / PreviousAskPrice;

		}
	}
}
