//using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ChrisNaborsWorks.Models;
using ChrisNaborsWorks.Sevices;
using System.Net.Mail;
using System.Net;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Http;

namespace ChrisNaborsWorks.Controllers
{
	public class HomeController : Controller
	{

		private IMailService _mailService;
		private IConfigurationRoot _config;
		private ICNWRepository _repository;

		public HomeController(IMailService mailService, IConfigurationRoot config, ICNWRepository repository)
		{
			_mailService = mailService;
			_config = config;
			_repository = repository;


		}
		public IActionResult Index()
		{

			return View("Index", "_Layout");
		}

		public IActionResult About()
		{
			return View("About", "_Layout");
		}

		public IActionResult VideoProductions()
		{
			return View("VideoProductions", "_Layout");
		}

		public IActionResult ApplicationDevelopment()
		{
			return View();
		}


		public IActionResult Contact()
		{
			return View();
		}

		public IActionResult CryptoPrices()
		{
			return View();
		}

		//[Authorize]
		//public IActionResult AppIndex()
		//{

		//	return View();
		//}

		//[Authorize]
		//public IActionResult Markets()
		//{
			

		//	return View(data);
		//}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Contact(ContactModel mod, IFormFileCollection files)
		{

			if (ModelState.IsValid)
			{
				var body = "<p>Email From:  {0}  ({1}</p> )";
				var message = new MailMessage();
				message.From = new MailAddress(mod.Email);
				message.To.Add(new MailAddress("cnabo001@yahoo.com"));
				message.Subject = mod.Subject;
				message.Body = string.Format(body, mod.Email, mod.Subject, mod.Message);
				message.IsBodyHtml = true;


				using (SmtpClient client = new SmtpClient())
				{
					var creds = new NetworkCredential
					{
						UserName = mod.Email,
						Password = mod.GetUserPass,
					};

					client.Credentials = creds;
					client.EnableSsl = true;

					if (mod.Email.Contains("@gmail.com"))
					{
						client.Host = "smtp.gmail.com";
						client.Port = 587;
					}
					else if (mod.Email.Contains("@yahoo.com"))
					{
						client.Host = "smtp.mail.yahoo.com";
						client.Port = 465;
					}
					else
					{
						client.Host = "smtp-mail.outlook.com";
						client.Port = 587;
					}


					client.Send(message);
					return RedirectToAction("Send");

				}

				

			}

			//if(mod.Upload != null)
			//{
			//	foreach (var file in files)
			//	{
			//		if (file.Length > 0)
			//		{
			//			var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');

			//			byte[] fileBytes = null;
			//			using (var fileStream = file.OpenReadStream())
			//			using (var ms = new MemoryStream())
			//			{
			//				fileStream.CopyTo(ms);
			//				fileBytes = ms.ToArray();
			//				//string s = Convert.ToBase64String(fileBytes);
			//				// act on the Base64 data
			//			}

			//			mod.Upload.Filename = fileName;
			//			fileIn.FileLength = Convert.ToInt32(file.Length);
			//			fileIn.FileType = file.ContentType;
			//			fileIn.FileTypeId = model.FileTypeId;
			//			fileIn.FileData = fileBytes;
			//			_repository.Add(fileIn);
			//			await _repository.SaveChangesAsync();
			//		}


			//	}

			return View(mod);
		}



		public IActionResult Send()
		{
			return View();
		}


		public ActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}


	}


	//_mailService.SendMail("cnabo001@yahoo.com", mod.Email, "From Chris Nabors Works:"+ "" + mod.Subject, mod.Message);







	//SmtpClient client = new SmtpClient("smtp.yahoo.com", 587);
	//client.EnableSsl = true;
	//client.Timeout = 100000;
	//client.DeliveryMethod = SmtpDeliveryMethod.Network;
	////client.UseDefaultCredentials = false;
	////client.Credentials = new NetworkCredential("cnabo001@yahoo.com", mod.Email, "From Chris Nabors Works", mod.Message);

	//MailMessage mailMessage = new MailMessage(mod.Email, "cnabo001@yahoo.com", mod.Subject, mod.Message);
	//mailMessage.IsBodyHtml = true;
	//mailMessage.BodyEncoding = UTF8Encoding.UTF8;
	//client.Send(mailMessage);







	//public class EmailSender
	//{
	//	/// <summary>
	//	/// Default SMTP Port.
	//	/// </summary>
	//	public static int SmtpPort = 25;

	//	public static bool Send(string from, string to, string subject, string body)
	//	{
	//		string domainName = GetDomainName(to);
	//		IPAddress[] servers = GetMailExchangeServer(domainName);
	//		foreach (IPAddress server in servers)
	//		{
	//			try
	//			{
	//				SmtpClient client = new SmtpClient(server.ToString(), SmtpPort);
	//				client.Send(from, to, subject, body);
	//				return true;
	//			}
	//			catch
	//			{
	//				continue;
	//			}
	//		}
	//		return false;
	//	}

	//	public static bool Send(MailMessage mailMessage)
	//	{
	//		string domainName = GetDomainName(mailMessage.To[0].Address);
	//		IPAddress[] servers = GetMailExchangeServer(domainName);
	//		foreach (IPAddress server in servers)
	//		{
	//			try
	//			{
	//				SmtpClient client = new SmtpClient(server.ToString(), SmtpPort);
	//				client.Send(mailMessage);
	//				return true;
	//			}
	//			catch
	//			{
	//				continue;
	//			}
	//		}
	//		return false;
	//	}

	//	public static string GetDomainName(string emailAddress)
	//	{
	//		int atIndex = emailAddress.IndexOf('@');
	//		if (atIndex == -1)
	//		{
	//			throw new ArgumentException("Not a valid email address", "emailAddress");
	//		}
	//		if (emailAddress.IndexOf('<') > -1 && emailAddress.IndexOf('>') > -1)
	//		{
	//			return emailAddress.Substring(atIndex + 1, emailAddress.IndexOf('>') - atIndex);
	//		}
	//		else
	//		{
	//			return emailAddress.Substring(atIndex + 1);
	//		}
	//	}

	//	public static IPAddress[] GetMailExchangeServer(string domainName)
	//	{
	//		IPHostEntry hostEntry = GetDomainUtil.GetIPHostEntryForMailExchange(domainName);
	//		if (hostEntry.AddressList.Length > 0)
	//		{
	//			return hostEntry.AddressList;
	//		}
	//		else if (hostEntry.Aliases.Length > 0)
	//		{
	//			return System.Net.Dns.GetHostAddresses(hostEntry.Aliases[0]);
	//		}
	//		else
	//		{
	//			return null;
	//		}
	//	}
	//}


	//public JsonResult SendEmail()
	//{
	//	bool result = false;
	//	result = SentMail("","","");

	//	return Json(result, JsonRequestBehavior.AllowGet);
	//}

	//public bool SentMail(ContactModel mod)
	//{
	//	try
	//	{


	//		SmtpClient client = new SmtpClient("smtp.yahoo.com", 587);
	//		client.EnableSsl = true;
	//		client.Timeout = 100000;
	//		client.DeliveryMethod = SmtpDeliveryMethod.Network;
	//		//client.UseDefaultCredentials = false;
	//		//client.Credentials = new NetworkCredential("cnabo001@yahoo.com", mod.Email, "From Chris Nabors Works", mod.Message);

	//		MailMessage mailMessage = new MailMessage(mod.Email, "cnabo001@yahoo.com", mod.Subject, mod.Message);
	//		mailMessage.IsBodyHtml = true;
	//		mailMessage.BodyEncoding = UTF8Encoding.UTF8;
	//		client.Send(mailMessage);



	//		return true;
	//	}
	//	catch(Exception ex)
	//	{
	//		return false;
	//	}
	//}

	
}

