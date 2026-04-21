using Xunit;
using GitHub.DistributedTask.WebApi;
using GitHub.Runner.Sdk;

namespace GitHub.Runner.Common.Tests.Listener
{
    public sealed class HardenedRunnerL0
    {

        [Fact]
        [Trait("Level", "L0")]
        [Trait("Category", "HardenedRunner")]
        public void TestSpoofedVersionIsValid()
        {
            // SpoofedVersion must be defined an parable to a valid version
            Assert.False(string.IsNullOrEmpty(HardenedRunnerBuildConstants.SpoofedVersion), "SdkConstants.HardenedRunnerBuildConstants.SpoofedVersion must be defined");
            Assert.True(PackageVersion.TryParse(HardenedRunnerBuildConstants.SpoofedVersion, out _), "SdkConstants.HardenedRunnerBuildConstants.SpoofedVersion must be a valid/parseble version string");
        }

        [Fact]
        [Trait("Level", "L0")]
        [Trait("Category", "HardenedRunner")]
        public void TestSpoofedVersionHasSameSpoofedMajorVersionAsRealVersion()
        {
            // SpoofedVersion must have the same Major version as the real version to prevent hard-reject
            Assert.True(PackageVersion.TryParse(HardenedRunnerBuildConstants.SpoofedVersion, out var spoofed));
            Assert.True(PackageVersion.TryParse(BuildConstants.RunnerPackage.Version, out var real));
            Assert.Equal(spoofed.Major, real.Major);
        }

        [Fact]
        [Trait("Level", "L0")]
        [Trait("Category", "HardenedRunner")]
        public void TestSpoofedVersionIsGreaterThanReal()
        {
            // SpoofedVersion must be greater or equal to the real version to prevent 30-day hard-reject
            var real = new PackageVersion(BuildConstants.RunnerPackage.Version);
            var spoofed = new PackageVersion(HardenedRunnerBuildConstants.SpoofedVersion);

            Assert.True(
            spoofed.CompareTo(real) >= 0,
            $"SpoofedVersion ({spoofed}) must be greater or equal to real version ({real})"
        );
        }

    }
}