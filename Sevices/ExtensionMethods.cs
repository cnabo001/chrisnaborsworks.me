using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChrisNaborsWorks.Sevices
{
    internal static class ExtensionMethods
    {

		public static String ToQueryString(this IDictionary<String, String> values)
		{
			return String.Join("&", values.Select(x => $"{x.Key}={x.Value}"));
		}

		public static DateTime fromDateTime(this Int64 thisTime)
		{
			var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
			return epoch.AddSeconds(thisTime);
		}

		public static long toDateTime(this DateTime date)
		{
			var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
			return Convert.ToInt64((date.ToUniversalTime() - epoch).TotalSeconds);
		}
    }
}
