using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectSupportSystem.Models
{
	public class Search
	{
		public bool Kosgeb { get; set; }
		public bool Tubitak { get; set; }
		public bool TicBak { get; set; }
		public decimal minAmount { get; set; }
		public decimal maxAmount { get; set; }
		public decimal minPercentage { get; set; }
		public decimal maxPercentage { get; set; }
		public decimal minPDuration { get; set; }
		public decimal maxDuration { get; set; }
	}
}
