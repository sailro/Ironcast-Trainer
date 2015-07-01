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
