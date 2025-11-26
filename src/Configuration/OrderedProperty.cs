using System.Reflection;

namespace TrainerKit.Configuration;

internal class OrderedProperty(ConfigurationPropertyAttribute attribute, PropertyInfo property)
{
	public ConfigurationPropertyAttribute Attribute { get; } = attribute;
	public PropertyInfo Property { get; } = property;
}
