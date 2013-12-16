using System;
using System.Web.Mvc;
using EPiServer.Web.Mvc;
using SampleSite.Business.LoadTesting;
using SampleSite.ContentModels.Pages.Test;

namespace SampleSite.Controllers
{
    public enum LoadScenario
    {
        PageWithoutEPiProperties = 0,
        PageWithEPiProperties = 1,
        EPiPropertiesChildren = 2,
        Children = 3
    }

    public class LoadTestController : PageController<LoadTestPage>
    {
        public ActionResult Index(LoadTestPage currentPage, int? sc, int? pages, int? steps)
        {
            var runner = new LoadTestRunner();
            var scenario = (LoadScenario) sc.GetValueOrDefault(0);

            Func<int, int, LoadResults> loadScenario;

            switch (scenario)
            {
                case LoadScenario.Children:
                    loadScenario = runner.Run<LoadWhenContentLoaderMethodUsed>;
                    break;
                case LoadScenario.PageWithEPiProperties:
                    loadScenario = runner.Run<LoadWhenPropertiesNotUsed>;
                    break;
                case LoadScenario.EPiPropertiesChildren:
                    loadScenario = runner.Run<LoadEPiPropertiesChildren>;
                    break;
                default:
                    loadScenario = runner.Run<LoadWithoutProperties>;
                    break;
            }

            var result = loadScenario(pages.GetValueOrDefault(100), steps.GetValueOrDefault(currentPage.Steps));

            result.Scenario = scenario.ToString();

            return View(result);
        }
    }
}