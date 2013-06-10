using System.Reflection;

namespace EPiProperties.Abstraction
{
    public interface IEPiPropertyGetter
    {
        object GetValue(object @object, PropertyInfo property);
    }
}