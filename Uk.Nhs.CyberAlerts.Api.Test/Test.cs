using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using Xunit;

namespace Uk.Nhs.CyberAlerts.Api.Test;

public abstract class Test(ITestOutputHelper testOutputHelper) : IDisposable
{
	private bool disposedValue;

	protected ITestOutputHelper Output { get; } = testOutputHelper;

	protected ILogger Logger { get; } = new XunitLoggerProvider(testOutputHelper, LogLevel.Debug)
		.CreateLogger("Test");

	protected static CancellationToken CancellationToken => TestContext.Current.CancellationToken;

	public CyberAlertClient Client { get; } = new CyberAlertClient();

	protected virtual void Dispose(bool disposing)
	{
		if (!disposedValue)
		{
			if (disposing)
			{
				Client.Dispose();
			}

			disposedValue = true;
		}
	}

	public void Dispose()
	{
		// Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}
}
