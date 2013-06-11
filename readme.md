EPiProperties
=============

*CURRENT STATUS* **DEBUG**


EPiProperties is a small library which allows you to quickly add auto-properties 
with a pre-defined behaviour to your EPiServer page types. 

The reason is to build a clean readable and testable API, 
and move the logic which evaluates these properties into a separate content data interceptor. 

Usage Sample - parent property
------------------------------

### Define property
In the example below I define a custom property `Parent` for my article page which refers to a parent page
(in my example site it has to be ListPage). 

    [ContentType(GUID = "{D45D87F2-E22E-4402-8F6D-7F72559C71F4}")]
    public class ArticlePage : ContentPageBase
    {
        [CmsParent]
        public virtual ListPage Parent { get; internal  set; }
    }
	
I used my custom data annotation attributes `CmsParent`,
but there are no restrictions on which attributes to use. 

And I want to simply use this property to get the parent page as the `ListPage` instance. 


### Implement property getter

To implement the property logic I need to implement `IEpiPropertyGetter` interface
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

For my implementation I use constructor injection and a couple utility classes (`TypeExtensions.Is<T>` 
and  `ObjectExtensions.Cast`

    public class ParentPropertyGetter : IEPiPropertyGetter
    {
        private readonly IContentLoader _contentLoader;
        protected virtual IContentLoader ContentLoader { get { return _contentLoader; } }

        public ParentPropertyGetter(IContentLoader contentLoader)
        {
            // inject content loader here
            _contentLoader = contentLoader;
        }

        public bool CanIntercept(PageData page, PropertyInfo property)
        {
            // we intercept property if it's declared with any PageData descendant. 
            return property.DeclaringType.Is<PageData>();
        }

        public object GetValue(PageData page, PropertyInfo property)
        {
            // the type from the property declaration
            var resultType = property.DeclaringType;
            // load parent page and cast it to the declaration type
            var result = ContentLoader.Get<PageData>(page.ParentLink).Cast(resultType);
            return result;
        }
    }


Under the hood
--------------
TBD