using System;
using UnityEngine;
using System.Collections.Generic;

namespace Ironcast.Trainer
{
	public class TrainerBehaviour : MonoBehaviour
	{

		private readonly Dictionary<KeyCode, Action> _actions = new Dictionary<KeyCode, Action>();

		void Start()
		{
			_actions.Clear();
			_actions.Add(KeyCode.KeypadMinus, () => PlayerCampaignData.Instance.CurrentScrap -= 1000);
			_actions.Add(KeyCode.KeypadPlus, () => PlayerCampaignData.Instance.CurrentScrap += 1000);
			_actions.Add(KeyCode.KeypadDivide, () => PlayerCampaignData.Instance.CurrentWarAssets -= 1000);
			_actions.Add(KeyCode.KeypadMultiply, () => PlayerCampaignData.Instance.CurrentWarAssets += 1000);
			_actions.Add(KeyCode.KeypadPeriod, () => PlayerCampaignData.Instance.TotalXP += 10000);
			_actions.Add(KeyCode.Keypad0, () =>
			{
				PlayerCampaignData.Instance.PlayerMechData.Mech_CurrentHealth = PlayerCampaignData.Instance.PlayerMechData.Mech_MaxHealth;
				PlayerCampaignData.Instance.PlayerMechData.Mech_CurrentAmmoAmount = PlayerCampaignData.Instance.PlayerMechData.Mech_MaxAmmoStorage;
				PlayerCampaignData.Instance.PlayerMechData.Mech_CurrentCoolantAmount = PlayerCampaignData.Instance.PlayerMechData.Mech_MaxCoolantStorage;
				PlayerCampaignData.Instance.PlayerMechData.Mech_CurrentEnergyAmount = PlayerCampaignData.Instance.PlayerMechData.Mech_MaxEnergyStorage;
				PlayerCampaignData.Instance.PlayerMechData.Mech_CurrentRepairAmount = PlayerCampaignData.Instance.PlayerMechData.Mech_MaxRepairStorage;
			});
		}

		void Update()
		{
			foreach (var keyCode in _actions.Keys)
			{
				if (Input.GetKeyDown(keyCode))
					_actions[keyCode]();
			}
		}
	}
}
