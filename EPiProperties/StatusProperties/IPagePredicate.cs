using EPiServer.Core;

namespace EPiProperties.StatusProperties
{
    /// <summary>
    /// Represents a page predicate: an expression about the page which can be true or false. 
    /// </summary>
    public interface IPagePredicate
    {
        bool Test(PageData page);
    }
}