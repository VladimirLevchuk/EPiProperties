using System.Web.Mvc;
using EPiServer.Web.Mvc;
using SampleSite.Models.Pages;

namespace SampleSite.Controllers
{
    public class SectionController : PageController<SectionPage>
    {
        public ActionResult Index(SectionPage currentPage)
        {
            return View(currentPage);
        }
    }
}