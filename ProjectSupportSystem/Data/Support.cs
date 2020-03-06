using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectSupportSystem.Data
{
	public class Support : Base
	{
		public Guid SupportPropertyID { get; set; }
		public virtual SupportProperty SupportPropertyOfSupport { get; set; }
		public Guid CategoryID { get; set; }
		public virtual Category CategoryOfSupport { get; set; } 
	}
}
