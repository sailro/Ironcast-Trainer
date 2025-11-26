using TrainerKit.Configuration;
using TrainerKit.Features;
using TrainerKit.Properties;
using UnityEngine;

namespace TrainerKit.IronCast;

internal class GetExperience : TriggerFeature
{
	public override string Name => Strings.FeatureGetExperienceName;
	public override string Description => Strings.FeatureGetExperienceDescription;

	[ConfigurationProperty(Order = 0)] 
	public override KeyCode Key { get; set; } = KeyCode.KeypadPeriod;

	[ConfigurationProperty]
	public int Amount { get; set; } = 10000;

	protected override void UpdateOnceWhenTriggered()
	{
		PlayerCampaignData.Instance?.TotalXP += Amount;
	}
}