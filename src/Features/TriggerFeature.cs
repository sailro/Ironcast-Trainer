using TrainerKit.Configuration;
using UnityEngine;

namespace TrainerKit.Features;

internal abstract class TriggerFeature : Feature
{
	[ConfigurationProperty(Order = 2)]
	public virtual KeyCode Key { get; set; } = KeyCode.None;

	private void Update()
	{
		if (Key != KeyCode.None && Input.GetKeyUp(Key))
			UpdateOnceWhenTriggered();
	}

	protected virtual void UpdateOnceWhenTriggered() { }
}
