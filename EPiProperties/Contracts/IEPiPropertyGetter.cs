using System.Reflection;
using EPiServer.Core;

namespace EPiProperties.Contracts
{
    /// <summary>
    /// Defines your custom EPi Property get logic. 
    /// Make it stateless and thread safe. 
    /// </summary>
    public interface IEPiPropertyGetter
    {
        /// <summary>
        /// Detects if the current property can be intercepted by our getter. 
        /// </summary>
        /// <param name="contentData"></param>
        /// <param name="property">Property information. </param>
        /// <returns>Returns true if the property value will be returned by the GetValue method; otherwise returns false. </returns>
        bool CanIntercept(IContentData contentData, PropertyInfo property);

        /// <summary>
        /// Gets the property value. 
        /// </summary>
        /// <param name="contentData">Page instance. </param>
        /// <param name="property">Property information. </param>
        /// <returns>Returns the calculated proeprty value</returns>
        object GetValue(IContentData contentData, PropertyInfo property);
    }
}