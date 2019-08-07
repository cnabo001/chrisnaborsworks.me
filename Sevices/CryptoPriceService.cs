using ChrisNaborsWorks.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp.Portable;
using RestSharp.Portable.HttpClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ChrisNaborsWorks.Sevices
{

	public class CryptoPriceService : Controller
	{

		private ILogger<CryptoPriceService> _logger;
		private IConfigurationRoot _config;
		private IRestClient _restClient;

		public CryptoPriceService(ILogger<CryptoPriceService> logger, IConfigurationRoot config)
		{
			_logger = logger;
			_config = config;

		}

		[HttpGet]
		public async Task<CryptoResponse<T>> SendAsync<T>(CryptoRequest request)
		{

			var url = "https://api.coinmarketcap.com";

			using (var client = new HttpClient())
			{

				var urBuild = new UriBuilder(url)
				{
					Path = request.RelativeUrl,
					Query = request.Properties.ToQueryString()
				};

				_restClient = new RestClient(url);

				var json = await client.GetAsync(urBuild.Uri);
				var info = await json.Content.ReadAsStringAsync();

				if (!json.IsSuccessStatusCode)
				{
					var error = JsonConvert.DeserializeObject<CryptoError>(info);
					throw new Exception(error.Message);

				}
				var results = JsonConvert.DeserializeObject<T>(info);

				return new CryptoResponse<T>
				{
					Result = results

				};

			}

		}


	}
	public class CryptoError
	{
		[JsonProperty("error")]
		public String Message { get; set; }
	}

	public class CryptoRequest
	{
		public String RelativeUrl { get; set; }
		public IDictionary<String, String> Properties { get; set; } = new Dictionary<String, String>();
	}

	public class CryptoResponse<T>
	{
		public T Result { get; set; }
	}



}
