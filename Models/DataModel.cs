using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChrisNaborsWorks.Models
{
    public class DataModel
    {
		public int Id { get; set; }
        public string Ticker { get; set; }
		public string Name { get; set; }
		public decimal Price { get; set; }

		public string video { get; set; }

		public string Category { get; set; }

		public ICollection<Likes> Likes { get; set; }
    }
}
