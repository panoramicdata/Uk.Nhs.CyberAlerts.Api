using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Uk.Nhs.CyberAlerts.Api.Data
{
	[DataContract]
	public class CveIdentifier
	{
		[DataMember(Name = "cveIdentifier")]
		public string Id{ get; set; }

		[DataMember(Name = "cveStatus")]
		public string CveStatus { get; set; }

		[DataMember(Name = "leaf")]
		public bool Leaf { get; set; }

		[DataMember(Name = "hippoDocumentBean")]
		public bool HippoDocumentBean { get; set; }

		[DataMember(Name = "hippoFolderBean")]
		public bool HippoFolderBean { get; set; }

		[DataMember(Name = "versionedNode")]
		public bool VersionedNode { get; set; }

		[DataMember(Name = "cveText")]
		public string CveText { get; set; }
	}
}
