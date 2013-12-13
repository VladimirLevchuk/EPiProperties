using System.Diagnostics;
using System.Reflection;
using EPiProperties.Contracts;
using EPiServer.DataAbstraction.RuntimeModel;

namespace EPiProperties.Infrastructure
{
    public class EPiPropertiesCustomContentScannerExtension : CustomContentScannerExtension
    {
        protected IEPiPropertiesRegistry EpiPropertiesRegistry { get; set; }

        public EPiPropertiesCustomContentScannerExtension(IEPiPropertiesRegistry epiPropertiesRegistry)
        {
            EpiPropertiesRegistry = epiPropertiesRegistry;
        }

        public override bool ShouldIgnoreProperty(ContentTypeModel contentTypeModel, PropertyInfo property)
        {
            bool isEpiProperty = IsEPiProperty(contentTypeModel, property);

            var result = isEpiProperty || base.ShouldIgnoreProperty(contentTypeModel, property);

            if (isEpiProperty)
            {
                Debug.WriteLine("[EPiProperties] EPiProperty detected: {0}.{1}", property.DeclaringType.FullName, property.Name);
            }

            if (!result)
            {
                Debug.WriteLine("[EPiProperties] Property to sync: {0}.{1}", property.DeclaringType.FullName, property.Name);
            }

            return result;
        }

        public virtual bool IsEPiProperty(ContentTypeModel contentTypeModel, PropertyInfo property)
        {
            return EpiPropertiesRegistry.IsEPiProperty(property);
        }
    }
}