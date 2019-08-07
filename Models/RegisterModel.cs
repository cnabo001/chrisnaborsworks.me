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
	
	public class RegisterModel
    {

		//public RegisterModel Create(ChrisNaborsWorksUser newUser)
		//{
		//	return new RegisterModel
		//	{
		//		UserName = newUser.UserName,
		//		MemberName = newUser.MemberName,
		//		EmailAddress = newUser.Email
		//	};

		//}


		[Key]
		public int UserId { get; set; }

		[DataMember]
		[Required(ErrorMessage ="User name is required")]
		[Display(Name = "User Name")]
		public string UserName { get; set; }

		[DataMember]
		[Required(ErrorMessage ="Password must be 8 characters")]
		[Display(Name = "Pass word")]
		[DataType(DataType.Password)]
		public string PassWord { get; set; }

		[DataMember]
		[Required(ErrorMessage ="a name is required")]
		[Display(Name = "Member Name/ Full Name")]
		public string MemberName { get; set; }

		[DataMember]
		[Required(ErrorMessage ="Must have vaild email address")]
		[Display(Name = "email address")]
		[DataType(DataType.EmailAddress)]
		public string EmailAddress { get; set; }




	}
}
