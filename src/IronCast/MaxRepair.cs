using TrainerKit.Features;
using TrainerKit.Properties;

namespace TrainerKit.IronCast;

internal class MaxRepair : ToggleFeature
{
	public override string Name => Strings.FeatureMaxRepairName;
	public override string Description => Strings.FeatureMaxRepairDescription;

	protected override void UpdateWhenEnabled()
	{
		var instance = PlayerCampaignData.Instance?.PlayerMechData;
		instance?.Mech_CurrentRepairAmount = instance.Mech_MaxRepairStorage;
	}
}
