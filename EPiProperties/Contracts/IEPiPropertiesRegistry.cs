using System.Collections.Generic;
using System.Reflection;

namespace EPiProperties.Contracts
{
    public interface IEPiPropertiesRegistry
    {
        IEnumerable<IEPiPropertyGetter> LookupGetters(PropertyInfo property);

        bool IsEPiProperty(PropertyInfo property);
    }
}