﻿using System.Web.Mvc;
using EPiServer.Web.Mvc;
using SampleSite.ContentModels.Pages;

namespace SampleSite.Controllers
{
    public class ListController : PageController<ListPage>
    {
        public ActionResult Index(ListPage currentPage)
        {
            return View(currentPage);
        }
    }
}