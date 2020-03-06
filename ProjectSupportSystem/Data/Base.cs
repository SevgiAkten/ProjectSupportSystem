using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectSupportSystem.Data
{
	public class Base
	{
		public Guid ID { get; set; }
		public DateTime ModifiedDate { get; set; }
		public DateTime CreatedDate { get; set; }
		public string Description { get; set; } 
	}
}
