using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectSupportSystem.Data
{
	public class SupPropSupElem : Base
	{
		public Guid SupportPropertyID { get; set; }
		public virtual SupportProperty SupportPropertyOfSupPropSupElem { get; set; }
		public Guid SupportElementID { get; set; }
		public virtual SupportElement SupportElementOfSupPropSupElem { get; set; } 

	}
}
