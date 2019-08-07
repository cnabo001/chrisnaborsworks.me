using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChrisNaborsWorks.Models;
using ChrisNaborsWorks.Sevices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ChrisNaborsWorks.Controllers
{
	//[Produces("application/json")]
	//[Route("api/Likes")]
	public class AppController : Controller
	{
		private DataContext _context;
		private ICNWRepository _repository;


		public AppController(DataContext context, ICNWRepository repository)
		{
			_context = context;
			_repository = repository;
		
		}

		public IActionResult AppIndex()
		{
			

			return View();
		}

		[Authorize]
		public IActionResult Markets()
		{
			var likes = _repository.GetAllLikes();
			return View(likes);
		}

		

		
	}
}