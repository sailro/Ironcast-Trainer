using TrainerKit.Configuration;
using UnityEngine;

namespace TrainerKit.Features;

internal abstract class HoldFeature : Feature
{
	[ConfigurationProperty(Order = 2)]
	public virtual KeyCode Key { get; set; } = KeyCode.None;

	protected virtual void Update()
	{
		if (Key != KeyCode.None && Input.GetKey(Key))
			UpdateWhenHold();
	}

	protected virtual void UpdateWhenHold() { }
}
