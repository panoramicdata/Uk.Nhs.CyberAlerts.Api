using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Uk.Nhs.CyberAlerts.Api.Data;

	[DataContract]
	public class RemediationStep
	{
		[DataMember(Name = "type")]
		public string Type { get; set; }

		[DataMember(Name = "link")]
		public string Link { get; set; }

		[DataMember(Name = "leaf")]
		public bool Leaf { get; set; }

		[DataMember(Name = "hippoDocumentBean")]
		public bool HippoDocumentBean { get; set; }

		[DataMember(Name = "hippoFolderBean")]
		public bool HippoFolderBean { get; set; }

		[DataMember(Name = "versionedNode")]
		public bool VersionedNode { get; set; }

		[DataMember(Name = "step")]
		public string Step { get; set; }
	}
