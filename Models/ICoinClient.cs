using ChrisNaborsWorks.Sevices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChrisNaborsWorks.Models
{
    public interface ICoinClient
    {
		List<string> GetConversionsList();

		CryptoPriceResult GetCryptoByID(string Id);
		CryptoPriceResult GetCryptoByID(string Id, string convertCurrency);

		IEnumerable<CryptoPriceResult> GetCurrency();
		IEnumerable<CryptoPriceResult> GetCurrency(string convertCurrency);
		IEnumerable<CryptoPriceResult> GetCurrency(int limit);
		IEnumerable<CryptoPriceResult> GetCurrency(int limit, string convertCurrency);
    }
}
