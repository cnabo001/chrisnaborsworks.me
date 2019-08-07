using System;

namespace ChrisNaborsWorks.Models
{
    public class ErrorViewModel
	{
		public string Name { get; set; }
		public string RequestId { get; set; }

	public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
	}
}