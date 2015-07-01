using UnityEngine;

namespace Ironcast.Trainer
{
	public class Loader
	{

		public static GameObject HookObject
		{
			get { return GameObject.Find("DialogUIController"); }
		}

		public static void Load()
		{
            HookObject.AddComponent<TrainerBehaviour>();
		}

		public static void Unload()
		{
			var component = HookObject.GetComponent<TrainerBehaviour>();
			if (component != null)
				Object.DestroyImmediate(component);
		}

	}
}
