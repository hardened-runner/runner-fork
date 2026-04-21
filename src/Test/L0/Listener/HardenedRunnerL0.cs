using Xunit;

namespace GitHub.Runner.Common.Tests.Listener
{
    public sealed class HardenedRunnerL0
    {
          [Fact]
          [Trait("Level", "L0")]
          [Trait("Category", "HardenedRunner")]
          public void TestVersionSpoofing()
          {
              Assert.Equal("2.999.0", HardenedRunnerBuildConstants.SpoofedVersion);
          }
    }
}