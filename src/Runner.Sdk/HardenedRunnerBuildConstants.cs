namespace GitHub.Runner.Sdk
{
    public static class HardenedRunnerBuildConstants
    {
        //
        // Keep alphabetical
        //

        // The version reported to GitHub API to prevent 30-day hard-reject.
        // Must be >= GitHub's minimum required version.
        public static readonly string SpoofedVersion = "2.999.0";

        // The real version is in BuildConstants.RunnerPackage.Version (auto-generated from runnerversion)
    }
}