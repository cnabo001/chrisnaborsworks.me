using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChrisNaborsWorks.ViewModels
{
    public class StoreViewModel
    {
		[Required]
		public string Name { get; set; }
		public string cryptoName { get; set; }

		public double Price { get; set; }
		public int supply { get; set; }
		public DateTime DateCreated { get; set; }
	}
}
