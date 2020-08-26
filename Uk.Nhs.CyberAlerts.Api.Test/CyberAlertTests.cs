using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

namespace Uk.Nhs.CyberAlerts.Api.Test
{
	public class CyberAlertTests : Test
	{
		public CyberAlertTests(ITestOutputHelper testOutputHelper) : base(testOutputHelper)
		{
		}

		[Fact]
		public async void GetSingle_Works()
		{
			const string requestedThreatId = "CC-3327";

			var alert = await Client
				.CyberAlerts
				.GetAsync(requestedThreatId)
				.ConfigureAwait(false);

			alert.Should().NotBeNull();
			alert.ThreatId.Should().Be(requestedThreatId);
		}

		[Fact]
		public async void GetPage_Works()
		{
			var page = await Client
				.CyberAlerts
				.GetPageAsync(1)
				.ConfigureAwait(false);

			page.Should().NotBeNull();
			page.PageSize.Should().Be(10);
			page.Total.Should().BeGreaterThan(1000);
		}
	}
}
