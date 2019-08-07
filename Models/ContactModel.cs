using System;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace ChrisNaborsWorks.Models
{
    public class ContactModel
    {
		
		[Required]
		[EmailAddress]
		public string Email { get; set; }

		[Required]
		public string Subject { get; set; }
		
		[Required]
		[StringLength(8000, MinimumLength = 10)]
		public string Message { get; set; }

		public IFormFileCollection Upload { get; set; }

		[Display(Name ="Email address password:")]
		public string GetUserPass { get; set;}
    }
}
