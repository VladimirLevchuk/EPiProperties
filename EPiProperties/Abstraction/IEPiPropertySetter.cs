using System.Reflection;

namespace EPiProperties.Abstraction
{
    public interface IEPiPropertySetter
    {
        object SetValue(object @object, PropertyInfo property, object value);
    }
}