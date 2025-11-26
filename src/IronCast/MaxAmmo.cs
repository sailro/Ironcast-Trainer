using TrainerKit.Features;
using TrainerKit.Properties;

namespace TrainerKit.IronCast;

internal class MaxAmmo : ToggleFeature
{
	public override string Name => Strings.FeatureMaxAmmoName;
	public override string Description => Strings.FeatureMaxAmmoDescription;

	protected override void UpdateWhenEnabled()
	{
		var instance = PlayerCampaignData.Instance?.PlayerMechData;
		instance?.Mech_CurrentAmmoAmount = instance.Mech_MaxAmmoStorage;
	}
}