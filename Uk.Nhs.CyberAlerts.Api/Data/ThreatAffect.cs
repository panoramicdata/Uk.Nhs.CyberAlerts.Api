using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Uk.Nhs.CyberAlerts.Api.Data;

	[DataContract]
	public class ThreatAffect
	{
		[DataMember(Name = "versionsAffected")]
		public IList<string> VersionsAffected { get; set; }

		[DataMember(Name = "leaf")]
		public bool Leaf { get; set; }

		[DataMember(Name = "hippoDocumentBean")]
		public bool HippoDocumentBean { get; set; }

		[DataMember(Name = "hippoFolderBean")]
		public bool HippoFolderBean { get; set; }

		[DataMember(Name = "versionedNode")]
		public bool VersionedNode { get; set; }

		[DataMember(Name = "platformText")]
		public string PlatformText { get; set; }
	}
