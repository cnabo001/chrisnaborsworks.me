using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Security.Claims;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Threading;

namespace ChrisNaborsWorks.Models
{
    public class ChrisNaborsWorksUser : IdentityUser
    {
		

		public string Likes { get; set; }
        

    }

}
