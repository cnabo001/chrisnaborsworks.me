using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ChrisNaborsWorks.Models
{
    public class Login
    {
       
		[Required]
		[Display(Name ="User Name")]
		public string UserName { get; set; }

		
		[Required]
		[Display(Name ="Pass word")]
		public string PassWord { get; set; }


    }
}
