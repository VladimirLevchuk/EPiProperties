namespace SampleSite.Business.LoadTesting
{
    public class LoadResults
    {
        public string Scenario { get; set; }

        public long StartupTime { get; set; }

        public long CleanupTime { get; set; }

        public long LoadTime { get; set; }

        public int Steps { get; set; }

        public int Pages { get; set; }

        public override string ToString()
        {
            return string.Format("Startup: {0}ms, Load: {1}ms, Cleanup: {2}ms",
                StartupTime, LoadTime, CleanupTime);
        }
    }
}