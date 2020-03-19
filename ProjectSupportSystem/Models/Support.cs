using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectSupportSystem.Models
{
	public class Support : Base
	{
		public string SupportType { get; set; }
		public string SupportName { get; set; }
		public string WhoApply { get; set; }
		public string Goal { get; set; }
		public string ApplicationProcessAndCondition { get; set; }
		public int SupportDuration { get; set; }
		public int SupportPercentage { get; set; }
		public decimal SupportAmount { get; set; }
		public string Code { get; set; }

		public int SupportSupElementID { get; set; }
		public virtual List<SupportSupElement> SupportsOfSupportSupElement { get; set; }
	}
}
