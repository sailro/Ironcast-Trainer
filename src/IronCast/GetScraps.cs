using TrainerKit.Configuration;
using TrainerKit.Features;
using TrainerKit.Properties;
using UnityEngine;

namespace TrainerKit.IronCast;

internal class GetScraps : TriggerFeature
{
	public override string Name => Strings.FeatureGetScrapsName;
	public override string Description => Strings.FeatureGetScrapsDescription;

	[ConfigurationProperty(Order = 0)]
	public override KeyCode Key { get; set; } = KeyCode.KeypadPlus;

	[ConfigurationProperty]
	public int Amount { get; set; } = 1000;

	protected override void UpdateOnceWhenTriggered()
	{
		PlayerCampaignData.Instance?.CurrentScrap += Amount;
	}
}
