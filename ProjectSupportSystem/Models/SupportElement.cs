using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectSupportSystem.Models
{
	public class SupportElement : Base
	{
		public string SupportElementName { get; set; }
		public int SupportElementPercentage { get; set; }
		public decimal SupportElementAmount { get; set; }
		public int SupportSupElementID { get; set; }
		public virtual List<SupportSupElement> SupportsOfSupportSupElement { get; set; }
	}
}
