using System.Web.Mvc;
using EPiServer.Web.Mvc;
using SampleSite.ContentModels.Pages;

namespace SampleSite.Controllers
{
    public class ArticleController : PageController<ArticlePage>
    {
        public ActionResult Index(ArticlePage currentPage)
        {
            return View(currentPage);
        }
    }
}