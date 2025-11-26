using TrainerKit.Features;
using TrainerKit.Properties;

namespace TrainerKit.IronCast;

internal class MaxCoolant : ToggleFeature
{
	public override string Name => Strings.FeatureMaxCoolantName;
	public override string Description => Strings.FeatureMaxCoolantDescription;

	protected override void UpdateWhenEnabled()
	{
		var instance = PlayerCampaignData.Instance?.PlayerMechData;
		instance?.Mech_CurrentCoolantAmount = instance.Mech_MaxCoolantStorage;
	}
}