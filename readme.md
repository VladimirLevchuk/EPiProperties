EPiProperties
=============

*CURRENT STATUS* **PERFORMANCE TESTING**


EPiProperties is a small library which allows you to quickly add auto-properties 
with a pre-defined behaviour to your EPiServer page types 

The reason is to build a clean readable and testable API, 
and move the logic which evaluates these properties into a separate content data interceptor. 

Take a look
-----------

* Just add meaningful properties to your content types and EPiProperties (available on nuget) will make them work for you.
* Feel free to add your own properties - it's easy

## Built-in properties

Navigation properties:  Children, Parent; status properties: IsAvailableForCurrentUser, IsPublished, IsAvailableInMenu are useful on the base page.
Pay attention to different ways of Descendents usage - if it's declared as `IEnumerable<ContentReference>` pages won't be loaded at all, 
just their references will be fetched into the result collection, otherwise EPiProperties will try to load pages and return only pages with type used in the collection definition. 

    public class PageBase: PageData
    {
        [CmsChildren]
        public virtual IEnumerable<PageBase> Children { get; internal set; }

        [CmsParent]
        public virtual PageBase Parent { get; internal set; }

        [CmsPublishedStatus]
        public virtual bool IsPublished { get; internal set; }

        [CmsPagePredicate(Predicate = typeof(AvailableForCurrentUser))]
        public virtual bool IsAvailableForCurrentUser { get; internal set; }

        [CmsPagePredicate(Predicate = typeof(AvailableInMenu))]
        public virtual bool IsAvailableInMenu { get; internal set; }
        
        [CmsAncestors]
        public virtual IEnumerable<PageBase> Ancestors { get; internal set; }

        [CmsDescendants]
        public virtual IEnumerable<PageBase> DescendentPages { get; internal set; }

        [CmsDescendants]
        public virtual IEnumerable<ContentReference> Descendents { get; internal set; }
        
    }
    
Another typed children        

    [ContentType(DisplayName = "[Content] Section", GUID = "{d304cb4a-59cb-43f3-af5d-8c6041e6239e}")]
    public class SectionPage : Base.PageBase
    {
        [CmsChildren]
        public virtual IEnumerable<FolderPage> Subsections { get; internal set; }
    }
    
IsPublishedAndReadableForCurrentUser is useful for folder (container) page which may not have assigned template (IsAvailableForCurrentUser filters such pages out)
    
    [ContentType(DisplayName = "[Container] Folder", GUID = "{528F664C-852F-4999-87B9-B1251A6A5376}")]
    public partial class FolderPage : Base.PageBase, IContentPagesContainer
    {
        [CmsPagePredicate(Predicate = typeof(IsPublishedAndReadableForCurrentUser))]
        public virtual bool IsPublishedAndReadableForCurrentUser { get; internal set; }

        [CmsChildren]
        public virtual IEnumerable<ContentPageBase> ContentPages { get; internal set; }
    }
    
Reference properties (just specify reference property name in the attribute and you'll get the typed access to the referenced page. 
If reference property marked with `Required` attribute, and reference is not specified exception will be thrown; otherwise it returns `null` ).
	
    [ContentType(DisplayName = "[Front] Carousel", 
        GUID = "{31c698ca-93ff-4d6c-83ad-4f49a3f7ac7a}", 
        Description = "Front Page Carousel",
        AvailableInEditMode = false)]
    [PropertyGroup]
    public class CarouselContentBlock : BlockBase
    {
        [Display(Name = "Carousel Root", Description = "Carousel will show child content pages for the page specified here", GroupName = SystemTabNames.Content, Order = 10)]
        public virtual PageReference CarouselRoot { get; set; }

        [CmsReference(LinkFieldName = "CarouselRoot")]
        public virtual IContentPagesContainer CarouselContainer { get; internal set; }        
    }
    
Reference property without name specified just looks for the property name + "Link" suffix.
	
    [ContentType(DisplayName = "[Content] List", GUID = "{63902AA5-690F-4634-9845-1CD74F89A87C}")]
    public class ListPage : Base.ContentPageBase, IContentPagesContainer
    {
        [CultureSpecific]
        public virtual PageReference ListRootLink { get; set; }

        [CmsReference]
        public virtual FolderPage ListRoot { get; internal set; }
    }
    
## Your own properties - it's simple    
Explore a couple [examples](https://github.com/VladimirLevchuk/EPiProperties/wiki#examples)

## For technical details 
Take a look [Under The Hood](https://github.com/VladimirLevchuk/EPiProperties/wiki/Under-the-hood)


    
    
    
    
    
