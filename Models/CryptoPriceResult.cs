using Newtonsoft.Json;
using System;

namespace ChrisNaborsWorks.Models
{
	public class CryptoPriceResult
	{
		public bool Success { get; set; }
		public string Message { get; set; }
		public string convert { get; set; }

		public int start { get; set; }
		public int limit { get; set; }

		public string sort { get; set; }
		public string structure {get; set;}

		[JsonProperty(PropertyName ="id")]
		public String Id { get; set; }

		[JsonProperty(PropertyName ="name")]
		public String Name { get; set; }

		[JsonProperty(PropertyName ="symbol")]
		public String Symbol { get; set; }

		[JsonProperty(PropertyName ="rank")]
		public Decimal Rank { get; set; }

		[JsonProperty(PropertyName = "price_usd")]
		public Decimal? PriceUsd { get; set; }

		[JsonProperty(PropertyName = "total_supply")]
		public Decimal? TotalSupply { get; set; }

		[JsonProperty(PropertyName = "24h_volume_usd")]
		public Decimal? twoFourVolume {get; set;}

		[JsonProperty(PropertyName = "market_cap_usd")]
		public Decimal? MarketCap { get; set;}

		[JsonProperty(PropertyName = "price_convert")]
		public string PriceConvert { get; set; }

		[JsonProperty(PropertyName = "24_volume_convert")]
		public string Volumne24Convert { get; set; }

		[JsonProperty(PropertyName = "market_cap_convert")]
		public string MarketCapConvert { get; set; }

		[JsonProperty(PropertyName ="last_updated")]
		public Int64? LastUpdated { get; set; }

		public string ConvertCurrency { get; set; }



	}
}