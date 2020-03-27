using System;
using System.ComponentModel;
using System.Resources;

namespace PipelineComponents
{
    #region ClaimCheckPipelineComponentPropertyDescriptor
    /// <summary>
    /// Cutom property descriptor
    /// </summary>
    public class ClaimCheckPipelineComponentPropertyDescriptor : PropertyDescriptor
	{
		private PropertyDescriptor descriptor;
		private ResourceManager resManager;

		public ResourceManager ResourceManager
		{
			get
			{
				return resManager;
			}
		}

		public ClaimCheckPipelineComponentPropertyDescriptor(PropertyDescriptor descriptor, ResourceManager resourceManager)
			: base(descriptor)
		{
			this.descriptor = descriptor;
			this.resManager = resourceManager;
		}

		public override AttributeCollection Attributes
		{
			get
			{
				return descriptor.Attributes;
			}
		}
		public override object GetEditor(Type editorBaseType)
		{
			return descriptor.GetEditor(editorBaseType);
		}

		public override string Category
		{
			get
			{
				return descriptor.Category;
			}
		}
		public override Type ComponentType
		{
			get
			{
				return descriptor.ComponentType;
			}
		}
		public override TypeConverter Converter
		{
			get
			{
				return descriptor.Converter;
			}
		}
		public override string Description
		{
			get
			{
				AttributeCollection attributes = descriptor.Attributes;

				ClaimCheckPipelineComponentDescriptionAttribute descriptionAttribute =
					(ClaimCheckPipelineComponentDescriptionAttribute)attributes[typeof(ClaimCheckPipelineComponentDescriptionAttribute)];

				if (descriptionAttribute == null)
					return descriptor.Description;

				string strId = descriptionAttribute.Description;
				if (resManager == null)
					return strId;

				return resManager.GetString(strId);
			}
		}
		public override bool DesignTimeOnly
		{
			get
			{
				return descriptor.DesignTimeOnly;
			}
		}
		public override bool IsBrowsable
		{
			get
			{
				return descriptor.IsBrowsable;
			}
		}
		public override bool IsLocalizable
		{
			get
			{
				return descriptor.IsLocalizable;
			}
		}
		public override bool IsReadOnly
		{
			get
			{
				return descriptor.IsReadOnly;
			}
		}
		public override Type PropertyType
		{
			get
			{
				return descriptor.PropertyType;
			}
		}
		public override bool ShouldSerializeValue(object o)
		{
			return descriptor.ShouldSerializeValue(o);
		}

		public override void AddValueChanged(object o, EventHandler handler)
		{
			descriptor.AddValueChanged(o, handler);
		}

		public override string DisplayName
		{
			get
			{
				AttributeCollection attributes = descriptor.Attributes;

				ClaimCheckPipelineComponentPropertyNameAttribute nameAttribute =
					(ClaimCheckPipelineComponentPropertyNameAttribute)attributes[typeof(ClaimCheckPipelineComponentPropertyNameAttribute)];

				if (nameAttribute == null)
					return descriptor.DisplayName;

				string strId = nameAttribute.PropertyName;
				if (resManager == null)
					return strId;

				return resManager.GetString(strId);
			}
		}
		public override string Name
		{
			get
			{
				return descriptor.Name;
			}
		}
		public override Object GetValue(object o)
		{
			return descriptor.GetValue(o);
		}
		public override void ResetValue(object o)
		{
			descriptor.ResetValue(o);
		}
		public override bool CanResetValue(object o)
		{
			return descriptor.CanResetValue(o);
		}
		public override void SetValue(object obj1, object obj2)
		{
			descriptor.SetValue(obj1, obj2);
		}
	}

#endregion

}
