using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.GData.Client;
using Google.GData.Extensions;
using Google.GData.YouTube;
using Google.GData.Extensions.MediaRss;
using Google.YouTube;

namespace ChrisNaborsWorks.Models
{
    public class VideosModel
    {
		public Video video { get; set; }
		public Name name { get; set; }
		
		public ICollection<Likes> Likes { get; set; }

		public VideosModel()
		{

		}
        
    }
}
