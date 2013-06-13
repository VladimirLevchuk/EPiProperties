EPiProperties
=============

*CURRENT STATUS* **PERFORMANCE TESTING**


EPiProperties is a small library which allows you to quickly add auto-properties 
with a pre-defined behaviour to your EPiServer page types. 

The reason is to build a clean readable and testable API, 
and move the logic which evaluates these properties into a separate content data interceptor. 

Take a look
-----------

Just add a couple meaningful properties to your page and EPiProperties will make them work for you

## Readable logic
My section page shows acrticles grouped in subsections. 
In the content tree it contains folders, and folder contains articles (content pages). 
All the page properties in the snippet below are powered by EPiProperties

        public virtual SubsectionsModel GetFoldersInSectionModel(SectionPage section)
        {
            if (section == null) throw new ArgumentNullException("section");

            var result = new SubsectionsModel
                {
                    Items = section.Subsections.Where(
                                    subsection => subsection.IsPublishedAndReadableForCurrentUser 
                                    && subsection.ContentPages.Any(contentPage => contentPage.IsAvailableForCurrentUser))
                                .Select(GetSubsectionModel)
                                .ToList()
                };

            return result;
        }
        
## Section page, base page    

Just add EPiProperties nugete to your project and pages below will work without any custom code

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
    }
    

    [ContentType(DisplayName = "[Content] Section", GUID = "{d304cb4a-59cb-43f3-af5d-8c6041e6239e}")]
    public class SectionPage : Base.PageBase
    {
        [CmsChildren]
        public virtual IEnumerable<FolderPage> Subsections { get; internal set; }
    }
    
    
    [ContentType(DisplayName = "[Container] Folder", GUID = "{528F664C-852F-4999-87B9-B1251A6A5376}")]
    public partial class FolderPage : Base.PageBase, IContentPagesContainer
    {
        [ScaffoldColumn(false)]
        public virtual string Foo { get; set; }

        [CmsPagePredicate(Predicate = typeof(IsPublishedAndReadableForCurrentUser))]
        public virtual bool IsPublishedAndReadableForCurrentUser { get; internal set; }

        [CmsChildren]
        public virtual IEnumerable<ContentPageBase> ContentPages { get; internal set; }
    }
    
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
    
    [ContentType(DisplayName = "[Content] List", GUID = "{63902AA5-690F-4634-9845-1CD74F89A87C}")]
    public class ListPage : Base.ContentPageBase, IContentPagesContainer
    {
        [Display(Order = 20)]
        [BackingType(typeof(PropertyPageReference))]
        [CultureSpecific]
        public virtual PageReference ListRootLink { get; set; }

        [CmsReference]
        public virtual FolderPage ListRoot { get; internal set; }

        [CmsChildren]
        public virtual IEnumerable<ContentPageBase> ContentPages { get; internal set; }
    }
    
    
    
    
    
    
    
