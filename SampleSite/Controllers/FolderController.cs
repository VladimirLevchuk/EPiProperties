using System.Web.Mvc;
using EPiServer.Web.Mvc;
using SampleSite.Models.Pages;

namespace SampleSite.Controllers
{
    public class FolderController : PageController<FolderPage>
    {
        public ActionResult Index(FolderPage currentPage)
        {
            return View(currentPage);
        }
    }
}