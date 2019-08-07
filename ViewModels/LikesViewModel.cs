using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChrisNaborsWorks.ViewModels
{
    public class LikesViewModel
    {
		[Required]
        public string Name { get; set; }
		public DateTime DateCreated { get; set; } = DateTime.UtcNow;
    }
}
