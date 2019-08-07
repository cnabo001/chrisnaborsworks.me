

namespace ChrisNaborsWorks.Models
{
	
		public partial class CryptoCurrencies
		{
		public int Id { get; set; }
			public int Code { get; set; }
			public int Item { get; set; }
			public string Name { get; set; }
			public string MarketCap { get; set; }
			public string Price { get; set; }
			public string Volume { get; set; }
			public string Supply { get; set; }
			public string Change { get; set; }
			public System.DateTime TimeStamp { get; set; }
			public string DateTimeStr
			{
				get
				{
					return TimeStamp.ToString("MM/dd/yyyy HH:mm:ss.fff");
				}
			}

		}
}