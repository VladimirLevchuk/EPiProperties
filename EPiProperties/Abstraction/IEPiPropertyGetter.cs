using System.Reflection;
using EPiServer.Core;

namespace EPiProperties.Abstraction
{
    public interface IEPiPropertyGetter
    {
        bool CanIntercept(PageData page, PropertyInfo property);

        object GetValue(PageData page, PropertyInfo property);
    }
}