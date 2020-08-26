using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Uk.Nhs.CyberAlerts.Api.Data
{
	[DataContract]
	public class Page<T>
	{
		[DataMember(Name = "pageSize")]
		public int PageSize { get; set; }

		[DataMember(Name = "total")]
		public int Total { get; set; }

		[DataMember(Name = "items")]
		public IList<T> Items { get; set; }

		[DataMember(Name = "totalPages")]
		public int TotalPages { get; set; }

		[DataMember(Name = "currentPage")]
		public int CurrentPage { get; set; }
	}
}
