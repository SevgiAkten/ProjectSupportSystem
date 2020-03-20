using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectSupportSystem.Models
{
	public class SupportElement : Base
	{
		[DisplayName("Adı")]
		public string SupportElementName { get; set; }

		[DisplayName("Oranı (%)")]
		public int SupportElementPercentage { get; set; }

		[DisplayName("Miktarı (TL)")]
		public decimal SupportElementAmount { get; set; }

		public int SupportSupElementID { get; set; }
		public virtual List<SupportSupElement> SupportsOfSupportSupElement { get; set; }
	}
}
