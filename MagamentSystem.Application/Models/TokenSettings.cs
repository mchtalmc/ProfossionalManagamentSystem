using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagamentSystem.Application.Models
{
	public class TokenSettings
	{
        public string ValidAuidence { get; set; }
        public string ValidIssuer { get; set; }
        public string Secret { get; set; }
        public int TokenValidityInMunites { get; set; }
        public int RefreshTokenValidtyInDats { get; set; }

    }
}
