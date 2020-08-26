using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Uk.Nhs.CyberAlerts.Api.Data
{
	[DataContract]
	public class Section
	{
		[DataMember(Name = "sectionType")]
		public string SectionType { get; set; }

		[DataMember(Name = "type")]
		public string Type { get; set; }

		[DataMember(Name = "title")]
		public string Title { get; set; }

		[DataMember(Name = "isNumberedList")]
		public bool IsNumberedList { get; set; }

		[DataMember(Name = "headingLevel")]
		public string HeadingLevel { get; set; }

		[DataMember(Name = "leaf")]
		public bool Leaf { get; set; }

		[DataMember(Name = "hippoDocumentBean")]
		public bool HippoDocumentBean { get; set; }

		[DataMember(Name = "hippoFolderBean")]
		public bool HippoFolderBean { get; set; }

		[DataMember(Name = "versionedNode")]
		public bool VersionedNode { get; set; }

		[DataMember(Name = "html")]
		public string Html { get; set; }
	}
}
