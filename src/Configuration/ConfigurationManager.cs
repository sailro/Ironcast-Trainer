using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using Newtonsoft.Json;
using TrainerKit.Features;
using TrainerKit.Properties;

namespace TrainerKit.Configuration;

internal static class ConfigurationManager
{
	public static JsonConverter[] Converters => [new ColorConverter(), new KeyCodeConverter()];

	public static void Load(string filename, Feature[] features, bool warnIfNotExists = true)
	{
		try
		{
			if (!File.Exists(filename))
			{
				if (warnIfNotExists)
					Context.AddConsoleLog(string.Format(Strings.ErrorFileNotFoundFormat, filename));

				return;
			}

			var lines = File.ReadAllLines(filename);

			foreach (var feature in features)
			{
				var featureType = feature.GetType();
				var properties = GetOrderedProperties(featureType);

				foreach (var op in properties)
				{
					var key = $"{featureType.FullName}.{op.Property.Name}=";
					try
					{
						var line = lines.FirstOrDefault(l => l.StartsWith(key));
						if (line == null)
							continue;

						var value = JsonConvert.DeserializeObject(line.Substring(key.Length), op.Property.PropertyType, Converters);
						op.Property.SetValue(feature, value, null);
					}
					catch (Exception)
					{
						Context.AddConsoleLog(string.Format(Strings.ErrorCorruptedPropertyFormat, key, filename));
					}
				}
			}

			Context.AddConsoleLog(string.Format(Strings.CommandLoadSuccessFormat, filename));
		}
		catch (Exception ioe)
		{
			Context.AddConsoleLog(string.Format(Strings.ErrorCannotLoadFormat, filename, ioe.Message));
		}
	}

	public static void Save(string filename, Feature[] features)
	{
		try
		{
			var content = new StringBuilder();
			content.AppendLine(Comment(Strings.CommandSaveHeader));
			content.AppendLine();

			foreach (var feature in features.OrderBy(f => f.GetType().FullName))
			{
				var featureType = feature.GetType();
				var properties = GetOrderedProperties(featureType);

				foreach (var op in properties)
				{
					var key = $"{featureType.FullName}.{op.Property.Name}";
					var value = JsonConvert.SerializeObject(op.Property.GetValue(feature, null), Formatting.None, Converters);

					var resourceId = op.Attribute.CommentResourceId;
					if (!string.IsNullOrEmpty(resourceId))
						content.AppendLine(Comment(Strings.ResourceManager.GetString(resourceId)));

					content.AppendLine($"{key}={value}");
				}

				if (properties.Any())
					content.AppendLine();
			}

			File.WriteAllText(filename, content.ToString());
			Context.AddConsoleLog(string.Format(Strings.CommandSaveSuccessFormat, filename));
		}
		catch (Exception ioe)
		{
			Context.AddConsoleLog(string.Format(Strings.ErrorCannotSaveFormat, filename, ioe.Message));
		}
	}

	private static string Comment(string value)
	{
		if (string.IsNullOrEmpty(value))
			return string.Empty;

		const string commentToken = "; ";
		const string resxNewLine = "\n";

		return commentToken + value!.Replace(resxNewLine, resxNewLine + commentToken);
	}

	public static bool IsSkippedProperty(Feature feature, string name)
	{
		return IsSkippedProperty(feature.GetType(), name);
	}

	public static bool IsSkippedProperty(Type featureType, string name)
	{
		var property = featureType.GetProperty(name, BindingFlags.Instance | BindingFlags.Public | BindingFlags.FlattenHierarchy);
		if (property == null)
			return false;

		var attribute = property.GetCustomAttributes(typeof(ConfigurationPropertyAttribute), true).OfType<ConfigurationPropertyAttribute>().FirstOrDefault();
		return attribute is { Skip: true };
	}

	public static OrderedProperty[] GetOrderedProperties(Type featureType)
	{
		var properties = featureType.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.FlattenHierarchy);

		return
		[.. properties
			.Select(p => new { property = p, attribute = p.GetCustomAttributes(typeof(ConfigurationPropertyAttribute), true).OfType<ConfigurationPropertyAttribute>().FirstOrDefault() })
			.Where(p => p.attribute is { Skip: false })
			.Select(op => new OrderedProperty(op.attribute!, op.property))
			.OrderBy(op => op.Attribute.Order)
			.ThenBy(op => op.Property.Name)
		];
	}
}
