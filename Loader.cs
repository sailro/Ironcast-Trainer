using UnityEngine;

namespace Ironcast.Trainer
{
	public class Loader
	{

		public static GameObject HookObject
		{
			get
			{
				var result = GameObject.Find(typeof(Loader).FullName);
				if (result != null) 
					return result;

				result = new GameObject(typeof(Loader).FullName);
				Object.DontDestroyOnLoad(result);

				return result;
			}
		}

		public static TrainerBehaviour Trainer
		{
			get
			{
				return HookObject.GetComponent<TrainerBehaviour>();
			}
		}

		public static void Load()
		{
			HookObject.AddComponent<TrainerBehaviour>();
		}

		public static void Unload()
		{
			Object.DestroyImmediate(Trainer);
			Object.DestroyImmediate(HookObject);
		}
	}
}
