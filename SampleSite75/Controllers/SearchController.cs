using System.Web.Mvc;
using EPiServer.Web.Mvc;
using SampleSite.ContentModels.Pages;

namespace SampleSite.Controllers
{
    public class SearchController : PageController<SearchPage>
    {
        public ActionResult Index(SearchPage currentPage)
        {
            return View(currentPage);
        }
    }
}