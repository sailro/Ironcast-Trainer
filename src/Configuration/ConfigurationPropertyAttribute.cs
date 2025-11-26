using System;

namespace TrainerKit.Configuration;

[AttributeUsage(AttributeTargets.Property)]
public class ConfigurationPropertyAttribute : Attribute
{
	public bool Skip { get; set; } = false;                        // Skip completely (Rendering+Config), useful when overriding properties
	public int Order { get; set; } = int.MaxValue;                 // Dislay order
	public string CommentResourceId { get; set; } = string.Empty;  // Link a resource id for generating comment in the ini file
	public bool Browsable { get; set; } = true;                    // Enable/Disable rendering
}
