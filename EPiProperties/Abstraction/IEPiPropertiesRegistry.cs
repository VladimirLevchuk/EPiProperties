using System.Collections.Generic;
using System.Reflection;

namespace EPiProperties.Abstraction
{
    public interface IEPiPropertiesRegistry
    {
        IEnumerable<IEPiPropertyGetter> LookupGetters(PropertyInfo property);
    }
}