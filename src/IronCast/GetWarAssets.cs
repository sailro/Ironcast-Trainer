using TrainerKit.Configuration;
using TrainerKit.Features;
using TrainerKit.Properties;
using UnityEngine;

namespace TrainerKit.IronCast;

internal class GetWarAssets : TriggerFeature
{
	public override string Name => Strings.FeatureGetWarAssetsName;
	public override string Description => Strings.FeatureGetWarAssetsDescription;

	[ConfigurationProperty(Order = 0)]
	public override KeyCode Key { get; set; } = KeyCode.KeypadMultiply;

	[ConfigurationProperty]
	public int Amount { get; set; } = 1000;

	protected override void UpdateOnceWhenTriggered()
	{
		PlayerCampaignData.Instance?.CurrentWarAssets += Amount;
	}
}
