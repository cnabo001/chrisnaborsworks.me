using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChrisNaborsWorks.Controllers.API
{
    [Produces("application/json")]
    [Route("api/VideoControllerApi")]
    public class VideoControllerApiController : Controller
    {
		[HttpGet("api/vidsearches")]
		public JsonResult Get()
		{
			return Json(new VidSearch() { Name = "My Search" });
		}
    }

	internal class VidSearch
	{
		public VidSearch()
		{

		}

		public string Name { get; set; }
	}
}