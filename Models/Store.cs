using System;

namespace ChrisNaborsWorks.Models
{
	public class Store
	{
		public int Id { get; set; }
		public string CryptoName { get; set; }

		public long? Price { get; set; }
		public long? supply { get; set; }
		public string VidName { get; set; }
		public DateTime addDate { get; set; }
	}
}