using Microsoft.Extensions.Logging;
using System;
using Xunit.Abstractions;

namespace Uk.Nhs.CyberAlerts.Api.Test
{
	public abstract class Test : IDisposable
	{
		private bool disposedValue;

		protected ILogger Logger { get; }

		protected Test(ITestOutputHelper testOutputHelper)
		{
			Client = new CyberAlertClient();

			Logger = testOutputHelper.BuildLogger();
		}

		public CyberAlertClient Client { get; }

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
}
