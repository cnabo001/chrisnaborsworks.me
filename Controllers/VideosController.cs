using System;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Google.GData.Client;
using Google.GData.Extensions;
using Google.GData.YouTube;
using Google.GData.Extensions.MediaRss;
using ChrisNaborsWorks.Models;
using System.Configuration;
using Google.YouTube;
using Microsoft.AspNetCore.Authorization;

namespace ChrisNaborsWorks.Controllers
{
	public class VideosController : Controller
	{
		//private VideoContext _Vcontext;
//		////[HttpPost]

//		[Authorize]
public IActionResult MusicVideos()  //VideoContext context
		{

		//_Vcontext = vContext;



			
			
			//var data = _Vcontext.Likes.ToList();

			
//			//int i = 0;


//			//YouTubeRequestSettings vidsets = new YouTubeRequestSettings("", "AIzaSyArPbtY0NyT63-gi8SW36rnW_BcahA7Qgg");
//			//YouTubeRequest request = new YouTubeRequest(vidsets);

//			//Feed<Video> feed = request.Get<Video>(new UrlHelperExtensions("http://"));
//			//List<Video> theVideo = feed.Entries.ToList();

//			//foreach (var item in theVideo)
//			//{
//			//	VideosModel videom = new VideosModel();
//			//	videom.video = item;
//			//	vidsets.Add(videom);
//			//}

//			//var info = request;
			//return View(data);

			return View();
		}


public IActionResult Commerical()
		{
			return View();
		}


public IActionResult Misc()
		{
			return View();
		}


		public IActionResult VideoCommer()
		{
			return View();
		}





		//public class MyYouTubeVideoObject
		//{
		//	public string VideoId { get; set; }
		//	public string Title { get; set; }
		//}
		//public class YouTubeVideo
		//{
		//	//const string MYYOUTUBE_CHANNEL = "SampleChannel";
		//	const string MyYOUTUBE_DEVELOPER_KEY =
		//	   "AIzaSyArPbtY0NyT63-gi8SW36rnW_BcahA7Qgg";

		//	public static MyYouTubeVideoObject[] GetVideos()
		//	{
		//		YouTubeRequestSettings settings =
		//		   new YouTubeRequestSettings("SampleChannel",
		//		   MyYOUTUBE_DEVELOPER_KEY);
		//		YouTubeRequest request = new YouTubeRequest(settings);
		//		string feedUrl = String.Format
		//		   ("http://gdata.youtube.com/feeds/api/users/{0}
		//		   / uploads ? orderby = published", MYYOUTUBE_CHANNEL);

		//		Feed < Video > videoFeed = request.Get<Video>
		//		   (new Uri(feedUrl));
		//		return (from video in videoFeed.Entries
		//				select new MyYouTubeVideoObject()
		//				{ VideoId = video.VideoId, Title = video.Title })
		//		   .ToArray();
		//	}

		//}




		//protected override void Onload(EventArgs e)
		//{
		//	base.OnActionExecuted(e);
		//		var embed = "<Html><Head>" + 
		//		"<meta http-equiv=\"X-UA-Compatible\" content = \"IE=Edge"/>" +
		//		"</head><body>" + "<iframe class = \"iframe\" id = \"fbfm\" allowfullscreen></iframe>" +
		//		"</body></html>";
		//	var url = "";
		//	this.webbrowser1.DocumentTest = string.Format(embed, url);
		//}
		//		//[HttpGet]
		//		//public IActionResult MusicVideos(string sortby)
		//		//{
		//		//	if (sortby != null)
		//		//	{
		//		//		if(sortby.Contains(':') && sortby.StartsWith("vi"))
		//		//		{
		//		//			string[] s = sortby.Split(':');
		//		//			string js = "http://" + s[1];
		//		//			ViewBag.tbjs = js;
		//		//		}
		//		//	}
		//		//	return View();
		//		//}

		//		public IActionResult Commercials()
		//		{
		//			return View();
		//		}
	}
}