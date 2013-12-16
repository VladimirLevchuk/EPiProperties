using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using EPiProperties.Contracts;
using EPiServer.ServiceLocation;

namespace EPiProperties
{
    public class EPiPropertiesSimpleRegistry : IEPiPropertiesRegistry
    {
        private readonly IEnumerable<Type> _getters;

        public EPiPropertiesSimpleRegistry(IEnumerable<Type> getters)
        {
            _getters = getters.Where(x => Util.TypeExtensions.Is<IEPiPropertyGetter>(x));
        }
        public virtual IEnumerable<IEPiPropertyGetter> LookupGetters(PropertyInfo property)
        {
            var result = _getters.Select(x => (IEPiPropertyGetter) ServiceLocator.Current.GetService(x));
            return result;
        }

        public virtual bool IsEPiProperty(PropertyInfo property)
        {
            return LookupGetters(property).Any();
        }
    }
}