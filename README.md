# Uk.Nhs.CyberAlerts.Api
A Nuget package for the UK NHS Cyber Alerts.

[![Nuget](https://img.shields.io/nuget/v/Uk.Nhs.CyberAlerts.Api)](https://www.nuget.org/packages/Uk.Nhs.CyberAlerts.Api/)

To use:

```C#
using Uk.Nhs.CyberAlerts.Api;

...

using var client = new CyberAlertClient();

// Get the first page of 10 alerts
var alertsPage = await client
	.GetPageAsync(1)
	.ConfigureAwait(false);

// Get a single alert
var alert = await client
	.GetAsync("CC-3327")
	.ConfigureAwait(false);
