using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectSupportSystem.Data
{
	public class SupportElement : Base
	{
		public string SupportElementName { get; set; }
		public int SupportElementPercentage { get; set; }
		public decimal SupportElementAmount { get; set; }
		public Guid SupPropSupElemID { get; set; }
		public virtual List<SupPropSupElem> SupPropElemsOfSupportElement { get; set; } 
	}
}
