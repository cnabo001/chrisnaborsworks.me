﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChrisNaborsWorks.Sevices
{
    public class UnixDateTimeConverter : JsonConverter
    {
		private static readonly DateTime UnixStartTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);

		public override bool CanConvert(Type objectType)
		{
			return objectType == typeof(DateTime);
		}

		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			if (reader.TokenType != JsonToken.Integer)
			{
				throw new Exception("Invaild token. Expected integer");
			}

			var totalSeconds = 0.0d;

			try
			{
				totalSeconds = Convert.ToDouble(reader.Value, CultureInfo.InvariantCulture);
			}
			catch
			{
				throw new Exception("Invalid double value.");
			}
			return UnixStartTime.AddSeconds(totalSeconds);
		}

		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			if(value is DateTime date)
			{
				var totalSeconds = (Int64)(date - UnixStartTime).TotalSeconds;
				writer.WriteValue(totalSeconds);
			}
			else
			{
				throw new ArgumentException(nameof(value));
			}
		}
	}
}
