using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using ChrisNaborsWorks.Models;
using ChrisNaborsWorks.ViewModels;
using AutoMapper;

namespace ChrisNaborsWorks.Controllers
{

	public class AuthController : Controller
	{
		private SignInManager<ChrisNaborsWorksUser> _signInManager;
		private UserManager<ChrisNaborsWorksUser> _userManager;
		//private UserStore<ChrisNaborsWorksUser> _userStore;

		private ICNWRepository _repository;

		public AuthController(SignInManager<ChrisNaborsWorksUser> signInManager, UserManager<ChrisNaborsWorksUser> userManager, ICNWRepository repository
		)
		{
			_signInManager = signInManager;
			_userManager = userManager;
			_repository = repository;

		}

		public IActionResult Login()
		{
			if (User.Identity.IsAuthenticated)
			{
				return RedirectToAction("App", "Markets");
			}

			return View();


		}

		//public IActionResult Logout()
		//{
		//	return View();
		//}

		[HttpPost]
		public async Task<ActionResult> Login(LoginViewModel lm, string returnUrl)
		{
			if (ModelState.IsValid)
			{
				var signInResult = await _signInManager.PasswordSignInAsync(
					lm.UserName,
					lm.PassWord,
					true, false);

				if (signInResult.Succeeded)
				{
					if (string.IsNullOrWhiteSpace(returnUrl))
					{

						return RedirectToAction("Markets", "App");

					}

					else
					{
						return Redirect(returnUrl);
					}
				}
				else
				{
					ModelState.AddModelError("", "Username or password not matching");
				}
			}

			return View();
		}

		//[HttpPost]
		//[ValidateAntiForgeryToken]
		public async Task<ActionResult> Logout()
		{
			if (User.Identity.IsAuthenticated)
			{
				await _signInManager.SignOutAsync();
			}
			return View("Logout" ,"Auth");
		}

		[HttpGet]
		public IActionResult Register()
		{
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Register(RegisterViewModel register)
		{
			if (ModelState.IsValid)
			{


				var user = await _userManager.FindByNameAsync(register.UserName);
				if (user == null)
				{
					user = new ChrisNaborsWorksUser()
					{
						Id = Guid.NewGuid().ToString(),
						UserName = register.UserName,
						Email = register.EmailAddress
						// MemberName = register.MemberName,
						// Join = register.Join.GetDate(DateTime.Now)
					};
				};
				var result = await _userManager.CreateAsync(user, register.Password);
				_repository.AddUser(register);

				if (result.Succeeded)
				{
					
					await _signInManager.SignInAsync(user, false);
					return RedirectToAction("AppIndex", "App");

				}
				else
				{
					foreach (var error in result.Errors)
					{
						ModelState.AddModelError("", error.Description);
					}

				}
				ModelState.Clear();
				ViewBag.Message = register.UserName + "Has been created";
			}
			return View(register);
		}


	}



}
