using System.Reflection;
using EPiProperties.Abstraction;
using EPiServer.Core;

namespace EPiProperties.NavigationProperties
{
    public class ReferencePropertyGetter : IEPiPropertyGetter
    {
        public bool CanIntercept(PageData page, PropertyInfo property)
        {
            throw new System.NotImplementedException();
        }

        public object GetValue(PageData page, PropertyInfo property)
        {
            throw new System.NotImplementedException();
        }
    }
}