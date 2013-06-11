using System.Reflection;
using EPiServer.Core;

namespace EPiProperties.Abstraction
{
    /// <summary>
    /// Defines your custom EPi Property get logic. 
    /// </summary>
    public interface IEPiPropertyGetter
    {
        /// <summary>
        /// Detects if the current property can be intercepted by our getter. 
        /// </summary>
        /// <param name="page">Page instance. </param>
        /// <param name="property">Property information. </param>
        /// <returns>Returns true if the property value will be returned by the GetValue method; otherwise returns false. </returns>
        bool CanIntercept(PageData page, PropertyInfo property);

        /// <summary>
        /// Gets the property value. 
        /// </summary>
        /// <param name="page">Page instance. </param>
        /// <param name="property">Property information. </param>
        /// <returns>Returns the calculated proeprty value</returns>
        object GetValue(PageData page, PropertyInfo property);
    }
}