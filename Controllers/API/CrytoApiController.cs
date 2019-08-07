using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ChrisNaborsWorks.Models;
using Microsoft.Extensions.Logging;

namespace ChrisNaborsWorks.Controllers.API
{
    [Produces("application/json")]
    [Route("api/CrytoApi")]
    public class CrytoApiController : Controller
    {
		
		//public IActionResult GetCryptoData()
		//{
		//	List<Cryp>
		//	return Ok(new CryptoCurrencies() { Name = "Crypto Currencies" });
		//}
	}
}