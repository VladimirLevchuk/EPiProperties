EPiProperties
=============

EPiProperties is a small library which allows you to quickly add auto-properties 
with a pre-defined behaviour to your EPiServer page types. 

The reason is to build a clean readable and testable API, 
and move the logic which evaluates these properties into a separate content data interceptor. 

Usage
-----
In the example below I define ChildArticles property for the list page


    [ContentType(GUID = "{37E9A1AC-BEF3-4B19-969D-D9C618C5CB20}")]
    public class ListPage : ContentPageBase
    {
        [CmsChildren]
        public virtual IEnumerable<ArticlePage> ChildArticles { get; internal set; }
    }
	
and mark it with my custom data annotation attribute (`CmsChildren`). 
And I want to simply use this property to get the page child articles. 
It's easy to use LINQ queries to process these data and very intuitive to write something like 

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
		
in unit tests. 		

Under the hood
--------------