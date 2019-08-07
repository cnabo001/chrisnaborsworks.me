using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ChrisNaborsWorks.Models;
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ChrisNaborsWorks.ViewModels;
using AutoMapper;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;

namespace ChrisNaborsWorks.Controllers
{
	
	[Route("api/LikesCrypto")]
	[Authorize]
	public class LikesCryptoController : Controller
	{
		private ICNWRepository _repositiry;
		private ILogger<LikesCryptoController> _logger;
		public LikesCryptoController(ICNWRepository repository, ILogger<LikesCryptoController> logger)
		{
			_repositiry = repository;
			_logger = logger;
		}


		[HttpGet("")]
		public IActionResult Get()
		{

			try
			{
				var results = _repositiry.GetLikesByUser(this.User.Identity.Name);

				return Ok(Mapper.Map<IEnumerable<LikesViewModel>>(results));
			}
			catch(Exception ex)
			{
				_logger.LogError($"Failed to get likes: {ex}");


					return BadRequest("Error Happened");
			}
		}

		[HttpPost("")]
		public async Task<IActionResult> Post([FromBody]LikesViewModel crypto)
		{
			if(ModelState.IsValid)
			{
				var newLike = Mapper.Map<Likes>(crypto);
				newLike.UserName = User.Identity.Name;
				_repositiry.AddLikes(newLike);

				if (await _repositiry.SaveChangesAsync())
				{

					return Created($"api/Crypto/{crypto.Name}", Mapper.Map<LikesViewModel>(crypto));
				}

			}
			return BadRequest("Failed to save like");
		}

	}
}