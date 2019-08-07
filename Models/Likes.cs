using System;
using System.Collections.Generic;

namespace ChrisNaborsWorks.Models
{
	public class Likes
	{
		public int Id { get; set; }
		public string UserName { get; set; }
		public string CryptoName { get; set; }
		public string Ticker { get; set; }
		public double Price { get; set; }
		public double Supply { get; set; }

		public string VidName { get; set; }

		public string VidCategory { get; set; }

		public DateTime DateCreated { get; set; }

		public ICollection<CryptoCurrencies> cryptoCurrencies { get; set; }

		public ICollection<Store> Store { get; set; }

	}
}