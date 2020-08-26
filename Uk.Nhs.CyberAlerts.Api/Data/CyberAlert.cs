using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Uk.Nhs.CyberAlerts.Api.Data
{
	[DataContract]
	public class CyberAlert
	{
		[DataMember(Name = "threatId")]
		public string ThreatId { get; set; }

		[DataMember(Name = "publishedDate")]
		public long PublishedDate { get; set; }

		[DataMember(Name = "sourceOfThreatUpdates")]
		public IList<string> SourceOfThreatUpdates { get; set; }

		[DataMember(Name = "cyberAcknowledgements")]
		public IList<object> CyberAcknowledgements { get; set; }

		[DataMember(Name = "threatType")]
		public string ThreatType { get; set; }

		[DataMember(Name = "threatvector")]
		public IList<object> Threatvector { get; set; }

		[DataMember(Name = "threatAffects")]
		public IList<ThreatAffect> ThreatAffects { get; set; }

		[DataMember(Name = "fullTaxonomyList")]
		public IList<object> FullTaxonomyList { get; set; }

		[DataMember(Name = "sections")]
		public IList<Section> Sections { get; set; }

		[DataMember(Name = "seosummaryJson")]
		public string SeosummaryJson { get; set; }

		[DataMember(Name = "shortsummary")]
		public string Shortsummary { get; set; }

		[DataMember(Name = "severity")]
		public string Severity { get; set; }

		[DataMember(Name = "category")]
		public IList<string> Category { get; set; }

		[DataMember(Name = "basePath")]
		public string BasePath { get; set; }

		[DataMember(Name = "threatUpdates")]
		public IList<object> ThreatUpdates { get; set; }

		[DataMember(Name = "remediationSteps")]
		public IList<RemediationStep> RemediationSteps { get; set; }

		[DataMember(Name = "indicatorsCompromise")]
		public IList<IndicatorsCompromise> IndicatorsCompromise { get; set; }

		[DataMember(Name = "ncscLink")]
		public string NcscLink { get; set; }

		[DataMember(Name = "cveIdentifiers")]
		public IList<CveIdentifier> CveIdentifiers { get; set; }

		[DataMember(Name = "title")]
		public string Title { get; set; }

		[DataMember(Name = "versionedNode")]
		public bool VersionedNode { get; set; }

		[DataMember(Name = "remediationIntro")]
		public string RemediationIntro { get; set; }

		[DataMember(Name = "summary")]
		public string Summary { get; set; }
	}
}
