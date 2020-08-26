using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Uk.Nhs.CyberAlerts.Api.Data
{
	[DataContract]
	public class IndicatorsCompromise
	{
		[DataMember(Name = "sectionType")]
		public string SectionType { get; set; }

		[DataMember(Name = "heading")]
		public string Heading { get; set; }

		[DataMember(Name = "audience")]
		public string Audience { get; set; }

		[DataMember(Name = "leaf")]
		public bool Leaf { get; set; }

		[DataMember(Name = "hippoDocumentBean")]
		public bool HippoDocumentBean { get; set; }

		[DataMember(Name = "hippoFolderBean")]
		public bool HippoFolderBean { get; set; }

		[DataMember(Name = "versionedNode")]
		public bool VersionedNode { get; set; }

		[DataMember(Name = "content")]
		public string Content { get; set; }
	}
}
