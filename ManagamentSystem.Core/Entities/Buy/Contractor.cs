using ManagamentSystem.Core.Entities.Wares;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagamentSystem.Core.Entities.Buy
{
	public class Contractor : BaseEntity
	{
        public string Name { get; set; }
        public string ContractorCode { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public int SueDetailsId { get; set; }
		public SueDetails SueDetails { get; set; }
	}
}
