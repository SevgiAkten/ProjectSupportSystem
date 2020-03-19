using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectSupportSystem.Models
{
	public class SupportSupElement : Base
	{
		public int SupportID { get; set; }
		public virtual Support SupportOfSupportSupElement { get; set; }
		public int SupportElementID { get; set; }
		public virtual SupportElement SupportElementOfSupportSupElement { get; set; }

	}
}
