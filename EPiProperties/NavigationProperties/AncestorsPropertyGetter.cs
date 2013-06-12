using System.Reflection;
using EPiProperties.Abstraction;
using EPiServer.Core;

namespace EPiProperties.NavigationProperties
{
    public class AncestorsPropertyGetter : IEPiPropertyGetter
    {
        public virtual object GetValue(IContentData contentData, PropertyInfo property)
        {
            throw new System.NotImplementedException();
        }

        public virtual bool CanIntercept(IContentData contentData, PropertyInfo property)
        {
            throw new System.NotImplementedException();
        }
    }
}