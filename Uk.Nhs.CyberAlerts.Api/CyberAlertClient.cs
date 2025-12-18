using Refit;
using System;
using System.Net.Http;
using Uk.Nhs.CyberAlerts.Api.Interfaces;

namespace Uk.Nhs.CyberAlerts.Api;

public class CyberAlertClient : IDisposable
{
	private bool disposedValue;
	private readonly HttpClient _httpClient;

	public CyberAlertClient()
	{
		_httpClient = new HttpClient
		{
			BaseAddress = new Uri("https://digital.nhs.uk/restapi/CyberAlert")
		};

		CyberAlerts = RestService.For<ICyberAlerts>(_httpClient);
	}

	public ICyberAlerts CyberAlerts { get; }

	protected virtual void Dispose(bool disposing)
	{
		if (!disposedValue)
		{
			if (disposing)
			{
				_httpClient.Dispose();
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
