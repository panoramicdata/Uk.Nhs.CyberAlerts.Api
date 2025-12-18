using AwesomeAssertions;
using System.Threading.Tasks;
using Xunit;

namespace Uk.Nhs.CyberAlerts.Api.Test;

public class CyberAlertTests(ITestOutputHelper testOutputHelper) : Test(testOutputHelper)
{
	[Fact]
	public async Task GetSingle_Works()
	{
		const string requestedThreatId = "CC-3327";

		var alert = await Client
			.CyberAlerts
			.GetAsync(requestedThreatId, cancellationToken: CancellationToken);

		alert.Should().NotBeNull();
		alert.ThreatId.Should().Be(requestedThreatId);
	}

	[Fact]
	public async Task GetPage_Works()
	{
		var page = await Client
			.CyberAlerts
			.GetPageAsync(1, cancellationToken: CancellationToken);

		page.Should().NotBeNull();
		page.PageSize.Should().Be(10);
		page.Total.Should().BeGreaterThan(1000);
	}
}
