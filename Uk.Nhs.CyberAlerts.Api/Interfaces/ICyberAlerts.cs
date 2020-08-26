using Refit;
using System.Threading;
using System.Threading.Tasks;
using Uk.Nhs.CyberAlerts.Api.Data;

namespace Uk.Nhs.CyberAlerts.Api.Interfaces
{
	public interface ICyberAlerts
	{
		/// <summary>
		/// Gets a page of Cyber Alerts
		/// </summary>
		/// <param name="page">The page number</param>
		/// <param name="limited">To return only the basic details of the alert, you can use the optional limited modifier</param>
		/// <param name="cancellationToken"></param>
		/// <returns>A page of alerts</returns>
		[Get("/page")]
		Task<Page<CyberAlert>> GetPageAsync(
			[AliasAs("page")] int page,
			[AliasAs("_limited")] bool limited = false,
			CancellationToken cancellationToken = default
			);

		/// <summary>
		/// Gets a single Cyber Alert
		/// </summary>
		/// <param name="threatId">You must specify a threat ID, normally formatted AA-1111</param>
		/// <param name="limited">To return only the basic details of the alert, you can use the optional limited modifier</param>
		/// <param name="cancellationToken">Optional CancellationToken</param>
		/// <returns>A single alert</returns>
		[Get("/single")]
		Task<CyberAlert> GetAsync(
			[AliasAs("threatid")] string threatId,
			[AliasAs("_limited")] bool limited = false,
			CancellationToken cancellationToken = default
			);
	}
}
