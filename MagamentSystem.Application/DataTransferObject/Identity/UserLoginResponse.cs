using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagamentSystem.Application.DataTransferObject.Identity
{
	public class UserLoginResponse
	{
        public bool AuthencticateResult { get; set; }
        public string AuthToken { get; set; }
        public DateTime AccessTokenExpiredDate { get; set; }
    }
    public class UserLoginErrorMessage : UserLoginResponse
    {
        public string Message { get; set; }
    }
}
