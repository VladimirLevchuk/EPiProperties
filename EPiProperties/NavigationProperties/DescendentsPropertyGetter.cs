using System.Reflection;
using EPiProperties.Abstraction;
using EPiServer.Core;

namespace EPiProperties.NavigationProperties
{
    public class DescendentsPropertyGetter : IEPiPropertyGetter
    {
        public virtual object GetValue(PageData page, PropertyInfo property)
        {
            throw new System.NotImplementedException();
        }

        public virtual bool CanIntercept(PageData page, PropertyInfo property)
        {
            throw new System.NotImplementedException();
        }
    }
}