using System;
using System.Collections;
using System.Reflection;

namespace PipelineComponents
{
	/// <summary>
	/// Implements an atribute for the custom property name
	/// </summary>
	[AttributeUsage(AttributeTargets.All, Inherited = true, AllowMultiple = false)]
	public sealed class ClaimCheckPipelineComponentPropertyNameAttribute : Attribute
	{
		private string propertyName;
		public ClaimCheckPipelineComponentPropertyNameAttribute(string propertyName)
		{
			this.propertyName = propertyName;
		}
		public string PropertyName
		{
			get
			{
				return propertyName;
			}
		}
	}

	/// <summary>
	/// Implements an attribute for the custom property description
	/// </summary>
	[AttributeUsage(AttributeTargets.All, Inherited = true, AllowMultiple = false)]
	public sealed class ClaimCheckPipelineComponentDescriptionAttribute : Attribute
	{
		private string description;
		public ClaimCheckPipelineComponentDescriptionAttribute(string description)
		{
			this.description = description;
		}
		public string Description
		{
			get
			{
				return description;
			}
		}
	}



}
