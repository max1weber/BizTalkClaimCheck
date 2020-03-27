using System;
using System.ComponentModel;
using System.Resources;

namespace PipelineComponents
{
   

    #region BaseCustomTypeDescriptor
    /// <summary>
    /// Custom type description for pipeline component properties
    /// </summary>
    public class BaseCustomTypeDescriptor : ICustomTypeDescriptor
	{
		private ResourceManager resourceManager;

		public BaseCustomTypeDescriptor(ResourceManager resourceManager)
		{
			this.resourceManager = resourceManager;
		}

		public AttributeCollection GetAttributes()
		{
			return new AttributeCollection(null);
		}
		public virtual string GetClassName()
		{
			return null;
		}
		public virtual string GetComponentName()
		{
			return null;
		}
		public TypeConverter GetConverter()
		{
			return null;
		}
		public EventDescriptor GetDefaultEvent()
		{
			return null;
		}
		public PropertyDescriptor GetDefaultProperty()
		{
			return null;
		}
		public object GetEditor(Type editorBaseType)
		{
			return null;
		}
		public EventDescriptorCollection GetEvents()
		{
			return EventDescriptorCollection.Empty;
		}
		public EventDescriptorCollection GetEvents(Attribute[] filter)
		{
			return EventDescriptorCollection.Empty;
		}

		public virtual PropertyDescriptorCollection GetProperties()
		{
			PropertyDescriptorCollection srcProperties = TypeDescriptor.GetProperties(this.GetType());
			ClaimCheckPipelineComponentPropertyDescriptor[] bteProperties = new ClaimCheckPipelineComponentPropertyDescriptor[srcProperties.Count];

			int i = 0;
			foreach (PropertyDescriptor srcDescriptor in srcProperties)
			{
				ClaimCheckPipelineComponentPropertyDescriptor destDescriptor = new ClaimCheckPipelineComponentPropertyDescriptor(srcDescriptor, resourceManager);
				AttributeCollection attributes = srcDescriptor.Attributes;
				bteProperties[i++] = destDescriptor;
			}
			PropertyDescriptorCollection destProperties = new PropertyDescriptorCollection(bteProperties);
			return destProperties;
		}

		public virtual PropertyDescriptorCollection GetProperties(Attribute[] filter)
		{
			return this.GetProperties();
		}

		public object GetPropertyOwner(PropertyDescriptor pd)
		{
			return this;
		}
	}
	#endregion
}
