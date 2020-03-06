using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectSupportSystem.Data
{
	public class Category : Base
	{
		public string CategoryName { get; set; }
		public bool IsPublicSupport { get; set; }
		public virtual List<Support> Supports { get; set; } 
	}
}
