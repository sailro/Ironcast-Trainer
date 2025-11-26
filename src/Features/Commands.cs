using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using TrainerKit.Configuration;
using TrainerKit.Properties;
using TrainerKit.UI;
using UnityEngine;

namespace TrainerKit.Features;

internal class Commands : FeatureRenderer
{
	public override string Name => Strings.FeatureCommandsName;
	public override string Description => Strings.FeatureCommandsDescription;

	[ConfigurationProperty(Skip = true)] // we do not want to offer save/load support for this
	public override bool Enabled { get; set; } = false;

	[ConfigurationProperty(Browsable = false)]
	public override float X { get; set; } = DefaultX;

	[ConfigurationProperty(Browsable = false)]
	public override float Y { get; set; } = DefaultY;

	public override KeyCode Key { get; set; } = KeyCode.RightAlt;

	[ConfigurationProperty(Browsable = false)]
	public Color ConsoleColor { get; set; } = Color.white;

	private bool Registered { get; set; } = false;
	private Dictionary<string, string> PropertyDisplays { get; } = [];

	protected override void Update()
	{
		if (Registered)
		{
			base.Update();
			return;
		}

		RegisterPropertyDisplays();

		// Load default configuration
		LoadSettings(false);
		SetupWindowCoordinates();

		Registered = true;
	}
	protected override void OnGUI()
	{
		Render.DrawString(new Vector2(8, Screen.height - 24), Context.LastConsoleLog, ConsoleColor, false);
		base.OnGUI();
	}

	private void RegisterPropertyDisplays()
	{
		const string prefix = nameof(OrderedProperty.Property);

		var properties = typeof(Strings)
				.GetProperties(BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public)
				.Where(p => p.Name.StartsWith(prefix));

		PropertyDisplays.Clear();

		foreach (var property in properties)
		{
			var key = property.Name.Substring(prefix.Length);
			var value = property.GetValue(null, null) as string ?? string.Empty;

			PropertyDisplays.Add(key, value);
		}
	}

	protected override string GetPropertyDisplay(string propertyName)
	{
		return PropertyDisplays.TryGetValue(propertyName, out var value)
			? value
			: $"!! [{propertyName}] !!"; // missing translation in Strings.resx
	}
}
