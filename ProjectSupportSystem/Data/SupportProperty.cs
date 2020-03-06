using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectSupportSystem.Data
{
	public class SupportProperty : Base
	{
		public string SupportName { get; set; }
		public string WhoApply { get; set; }
		public string Goal { get; set; }
		public string ApplicationProcessAndCondition { get; set; }
		public int SupportDuration { get; set; }
		public int SupportPercentage { get; set; }
		public decimal SupportAmount { get; set; } 
		public string Code { get; set; }
		public virtual List<Support> Supports { get; set; }
		public Guid SupPropSupElemID { get; set; }
		public virtual List<SupPropSupElem> SupPropElemsOfSupportProperty { get; set; } 


	}
}
