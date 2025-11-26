using Newtonsoft.Json;
using UnityEngine;

namespace TrainerKit.Features;

internal interface IFeature
{
	[JsonIgnore]
	public string Name { get; }
}

internal abstract class Feature : MonoBehaviour, IFeature
{
	public abstract string Name { get; }
	public abstract string Description { get; }

	protected void AddConsoleLog(string log)
	{
		Context.AddConsoleLog(log);
	}
}
