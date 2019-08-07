using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ChrisNaborsWorks.Models;
using Microsoft.Extensions.Logging;
using AutoMapper;
using ChrisNaborsWorks.ViewModels;
using ChrisNaborsWorks.Sevices;
using Microsoft.AspNetCore.Authorization;
using ChrisNaborsWorks.Queries;
using CoinMarketCap;
using CoinMarketCap.Options;

namespace ChrisNaborsWorks.Controllers.API
{
	[Authorize]
	[Route("api/Likes/{CryptoName}/Store")]
    public class StoreCryptoController : Controller
    {
		private ICNWRepository _repositiry;
		private ILogger<StoreCryptoController> _logger;
		private ICoinClient _cryptoPriceService;
		public StoreCryptoController(ICNWRepository repository, ILogger<StoreCryptoController> logger, ICoinClient cryptoPriceService)
		{
			_repositiry = repository;
			_logger = logger;
			_cryptoPriceService = cryptoPriceService;
		}

		[HttpGet("")]
		public IActionResult Get(string cryptoName)
		{
			try
			{
				var like = _repositiry.GetUserCryptoByName(cryptoName, User.Identity.Name);


			return Ok(Mapper.Map<IEnumerable<StoreViewModel>>(like.CryptoName.ToList()));
			}
			catch (Exception ex)
			{
				_logger.LogError("Failed to get Crypto Name: {0}", ex);
			}
			return BadRequest("Error");
		}

		[HttpPost("")]
		public async Task<IActionResult> Post(string cryptoName, [FromBody]StoreViewModel vm)
		{


			try
			{
				if (ModelState.IsValid)
				{
					var newStore = Mapper.Map<Store>(vm);
					var client = new CoinMarketCapClient();
					var result = await client.GetTickerAsync();
					//if (!result)
					//{
					//	_logger.LogError("Cant find it");
					//}
					//else
					{
						newStore.Price = result.Data.LastUpdated;
						newStore.supply = result.Data.MaxSupply;
						newStore.CryptoName = result.Data.Name;

						_repositiry.AddStore(cryptoName, newStore, User.Identity.Name);

						if (await _repositiry.SaveChangesAsync())
						{
							return Created($"/api/Likes/{cryptoName}/Store/{newStore.CryptoName}",
							Mapper.Map<StoreViewModel>(newStore));
						}

					}
				}
			}
			catch (Exception ex)
			{
				_logger.LogError("Failed to save new like: {0}", ex);
			}
			return BadRequest("Failed");

		}


	}
}
