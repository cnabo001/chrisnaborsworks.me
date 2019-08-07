using ChrisNaborsWorks.Models;
using ChrisNaborsWorks.Sevices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChrisNaborsWorks.Queries
{
    public static class CryptoQuerries
    {
        public static async Task<CryptoPriceResult[]> GetCryptosAsync(this CryptoPriceService crypto, Int32 limit = 100)
		{
			var request = new CryptoRequest
			{
				RelativeUrl = "/v2/ticker",
				Properties = new Dictionary<String, String>
				{
					["limit"] = limit.ToString()
				}
			};
			var response = await crypto.SendAsync<CryptoPriceResult[]>(request);
			return response.Result;
		}
    }
}
