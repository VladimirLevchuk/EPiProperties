EPiProperties
=============

*STATUS*: debug


EPiProperties is a small library which allows you to quickly add auto-properties 
with a pre-defined behaviour to your EPiServer page types. 

The reason is to build a clean readable and testable API, 
and move the logic which evaluates these properties into a separate content data interceptor. 

Usage
-----


### Define property
In the example below I define a custom property `ChildArticles` for my list page. 

    [ContentType(GUID = "{37E9A1AC-BEF3-4B19-969D-D9C618C5CB20}")]
    public class ListPage : ContentPageBase
    {
        [CmsChildren]
        public virtual IEnumerable<ArticlePage> ChildArticles { get; internal set; }
    }
	
I used my custom data annotation attributes `CmsChildren`,
but there are no restrictions on which attributes to use. 

And I want to simply use this property to get the page 1-st level children of the `ArticlePage` type. 
It's easy to use LINQ queries to process these data and very intuitive to write something like the following 
in the unit tests:

        [Test]
        public void GetPageModel_ReturnsChildArticlesAvailableForCurrentUser()
        {
            var list = new ListPage
            {
                Children = new []
                        {
                            new ArticlePage { IsAvailaibleForCurrentUser = true },
                            new ArticlePage { IsAvailaibleForCurrentUser = false }
                        }
            };

            var result = Orchestrator.GetPageModel(list);

            result.ArticlesList.Items.Count.Should().Be(1);
        }
	
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




Under the hood
--------------
TBD