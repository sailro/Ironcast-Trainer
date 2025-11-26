using TrainerKit.Features;
using TrainerKit.Properties;

namespace TrainerKit.IronCast;

internal class MaxEnergy : ToggleFeature
{
	public override string Name => Strings.FeatureMaxEnergyName;
	public override string Description => Strings.FeatureMaxEnergyDescription;

	protected override void UpdateWhenEnabled()
	{
		var instance = PlayerCampaignData.Instance?.PlayerMechData;
		instance?.Mech_CurrentEnergyAmount = instance.Mech_MaxEnergyStorage;
	}
}
