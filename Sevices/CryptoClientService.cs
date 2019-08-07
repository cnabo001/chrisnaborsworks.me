using ChrisNaborsWorks.Models;
using Newtonsoft.Json;
using RestSharp.Portable;
using RestSharp.Portable.HttpClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChrisNaborsWorks.Sevices
{
    public class CryptoClientService
    {
		private IRestClient _restClient { get; set; }

		public CryptoClientService(string url)
		{
			_restClient = new RestClient(url);
		}

		public List<CryptoPriceResult> MakeRequest(string resource, Method method, string convertCurrency)
		{
			var request = new RestRequest(resource, method);
			Task<IRestResponse> task = _restClient.Execute(request);
			var content = task.Result.Content;

			if (!String.IsNullOrEmpty(convertCurrency))
			{
				content = content.Replace("price_" + convertCurrency.ToLower(), "price_convert");
				content = content.Replace("24_volume_" + convertCurrency.ToLower(), "24_volume_convert");
				content = content.Replace("market_cap_" + convertCurrency.ToLower(), "market_cap_convert");
			}
			List<CryptoPriceResult> result = JsonConvert.DeserializeObject<List<CryptoPriceResult>>(content);
			result.ForEach(r => r.ConvertCurrency = convertCurrency);
			return result;
		}

		public static RestRequest CreateRequest(string resource, Method method)
		{
			var taskRequest = new RestRequest(resource, method);
			taskRequest.Parameters.Clear();

			taskRequest.AddHeader("", $"");
			return taskRequest;
		}



	}



}
