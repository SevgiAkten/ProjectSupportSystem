using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectSupportSystem.Models
{
	public class Support : Base
	{
		[DisplayName("Türü")]
		public string SupportType { get; set; }

		[DisplayName("Adı")]
		public string SupportName { get; set; }

		[DisplayName("Kimler Başvurabilir?")]
		public string WhoApply { get; set; }

		[DisplayName("Amacı")]
		public string Goal { get; set; }

		[DisplayName("Başvuru Süreci ve Şekli")]
		public string ApplicationProcessAndCondition { get; set; }

		[DisplayName("Süresi (Ay)")]
		public int SupportDuration { get; set; }

		[DisplayName("Oranı (%)")]
		public int SupportPercentage { get; set; }

		[DisplayName("Miktarı (TL)")]
		public decimal SupportAmount { get; set; }

		[DisplayName("Kodu")]
		public string Code { get; set; }

		public int SupportSupElementID { get; set; }
		public virtual List<SupportSupElement> SupportsOfSupportSupElement { get; set; }
	}
}
