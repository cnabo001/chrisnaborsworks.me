using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChrisNaborsWorks.Sevices;
using RestSharp.Portable;

namespace ChrisNaborsWorks.Models
{
    public class CoinClient : ICoinClient
    {
		private const string url = "http://api.coinmarketcap.com";
		private const string Path = "/v1/ticker";

		
		List<string> ICoinClient.GetConversionsList()
		{
			return new List<string> { "KRW", "JPY", "BRL", "CAD", "AUD", "IDR", "EUR" };
		}

		CryptoPriceResult ICoinClient.GetCryptoByID(string Id)
		{
			return CryptoByID(Id, string.Empty);
		}

		CryptoPriceResult ICoinClient.GetCryptoByID(string Id, string convertCurrency)
		{
			return CryptoByID(Id, convertCurrency);
		}

		private CryptoPriceResult CryptoByID(string Id, string convertCurrency)
		{
			string path = "/" + Id;
			if(!string.IsNullOrEmpty(convertCurrency))
			{
				path += "/?convert=" + convertCurrency;
			}
			var client = new CryptoClientService(url);
			var result = client.MakeRequest(Path + path, Method.GET, convertCurrency);

			return  result.First();
		}

		IEnumerable<CryptoPriceResult> ICoinClient.GetCurrency()
		{
			return Cryptos(-1, string.Empty);
		}

		IEnumerable<CryptoPriceResult> ICoinClient.GetCurrency(string convertCurrency)
		{
			return Cryptos(-1, convertCurrency);
		}

		IEnumerable<CryptoPriceResult> ICoinClient.GetCurrency(int limit)
		{
			return Cryptos(limit, string.Empty);
		}

		IEnumerable<CryptoPriceResult> ICoinClient.GetCurrency(int limit, string convertCurrency)
		{
			return Cryptos(limit, convertCurrency);
		}

		private List<CryptoPriceResult> Cryptos(int limit, string convertCurrency)
		{


			string seperator = string.Empty;
			string path = "?";

			path += "limit=" + limit;
			seperator = "&";

			if (!string.IsNullOrEmpty(convertCurrency))
			{
				path += seperator + "convert=" + convertCurrency;
			}
			var client = new CryptoClientService(url);
			var result = client.MakeRequest(Path + path, Method.GET, convertCurrency);
			return result;
		}

	}


}
