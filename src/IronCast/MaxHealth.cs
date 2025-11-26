using TrainerKit.Features;
using TrainerKit.Properties;

namespace TrainerKit.IronCast;

internal class MaxHealth : ToggleFeature
{
	public override string Name => Strings.FeatureMaxHealthName;
	public override string Description => Strings.FeatureMaxHealthDescription;

	protected override void UpdateWhenEnabled()
	{
		var instance = PlayerCampaignData.Instance?.PlayerMechData;
		instance?.Mech_CurrentHealth = instance.Mech_MaxHealth;
	}
}