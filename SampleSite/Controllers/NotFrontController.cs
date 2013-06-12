using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using EPiServer;
using EPiServer.Core;
using EPiServer.Framework.DataAnnotations;
using EPiServer.Web.Mvc;
using SampleSite.Models.Pages;

namespace SampleSite.Controllers
{
    public class NotFrontController : PageController<FrontPage>
    {
        public ActionResult Index(FrontPage currentPage)
        {
            return View(currentPage);
        }
    }
}