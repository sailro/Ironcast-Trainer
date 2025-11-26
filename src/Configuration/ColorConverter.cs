using System;
using Newtonsoft.Json;
using UnityEngine;

namespace TrainerKit.Configuration;

public class ColorConverter : JsonConverter
{
	public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
	{
		if (value is not Color color)
			return;

		serializer.Serialize(writer, new[] { color.r, color.g, color.b, color.a });
	}

	public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
	{
		var array = serializer.Deserialize<float[]>(reader);

		if (Nullable.GetUnderlyingType(objectType) == typeof(Color))
		{
			// Handle Nullable<Color> and previous bug saving a <null> as Color.clear
			if (array is null || new Color(array[0], array[1], array[2], array[3]) == Color.clear)
				return null!;
		}

		return array is null ? Color.clear : new Color(array[0], array[1], array[2], array[3]);
	}

	public override bool CanConvert(Type objectType)
	{
		return objectType == typeof(Color);
	}
}
