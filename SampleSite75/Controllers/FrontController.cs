using System.Web.Mvc;
using EPiServer.Web.Mvc;
using SampleSite.ContentModels.Pages;

namespace SampleSite.Controllers
{
    public class FrontController : PageController<FrontPage>
    {
        public ActionResult Index(FrontPage currentPage)
        {
            return View(currentPage);
        }
    }
}