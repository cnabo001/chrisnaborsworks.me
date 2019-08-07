using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ChrisNaborsWorks.ViewModels
{
    public class RegisterViewModel
    {
		//static int incID = 0;
		[Key]
		public string ID { get; set; } 

		[DataMember, MaxLength(256)]
		[Required(ErrorMessage = "User name is required")]
		[Display(Name = "User Name")]
		public string UserName { get; set; }

		[DataMember, MinLength(8)]
		[Required(ErrorMessage = "Password must be 8 characters")]
		[Display(Name = "Password")]
		[DataType(DataType.Password)]
		public string Password { get; set; }

		
		[Display(Name = "Confirm Password")]
		[Compare("Password", ErrorMessage ="Password not matching")]
		[DataType(DataType.Password)]
		public string ConfirmPassWord { get; set; }

		//[DataMember]
		//[Required(ErrorMessage = "a name is required")]
		//[Display(Name = "Member Name/ Full Name")]
		//public string MemberName { get; set; }

		[DataMember, MaxLength(256)]
		[Required(ErrorMessage = "Must have vaild email address")]
		[Display(Name = "email address")]
		[DataType(DataType.EmailAddress)]
		public string EmailAddress { get; set; }

		//[DataType(DataType.DateTime)]
		//public DateTime Join { get; set; }
	}
}
