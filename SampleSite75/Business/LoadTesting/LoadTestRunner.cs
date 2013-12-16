using System.Diagnostics;
using EPiServer.ServiceLocation;

namespace SampleSite.Business.LoadTesting
{
    public class LoadTestRunner
    {
        public virtual LoadResults Run<TScenario>(int pages = 100, int steps = 1000)
            where TScenario: LoadScenario
        {
            var result = new LoadResults
                {
                    Pages = pages,
                    Steps = steps
                };

            var scenario = ServiceLocator.Current.GetInstance<TScenario>();
            scenario.Pages = pages;

            var swStartup = Stopwatch.StartNew();

            scenario.Startup();

            swStartup.Stop();

            result.StartupTime = swStartup.ElapsedMilliseconds;

            var swLoad = Stopwatch.StartNew();

            for (int step = 1; step <= steps; ++step)
            {
                scenario.BeforeEachLoad();
                scenario.LoadStep();
                scenario.AfterEachLoad();
            }

            swLoad.Stop();

            result.LoadTime = swLoad.ElapsedMilliseconds;

            var swCleanup = Stopwatch.StartNew();
            scenario.Cleanup();

            swCleanup.Stop();

            result.CleanupTime = swCleanup.ElapsedMilliseconds;

            return result;
        }
    }
}