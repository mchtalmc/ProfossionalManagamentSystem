using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagamentSystem.Application.DataTransferObject
{
	public class BaseResponse<T>
	{
        public T Body { get; set; }
        public bool IsSuccess { get; set; }
        public string Message { get; set; }

		public BaseResponse(T? body, bool ısSuccess=true, string message="")
		{
			Body = body;
			IsSuccess = ısSuccess;
			Message = message;
		}

		public BaseResponse(bool ısSuccess=true, string message="")
		{
			IsSuccess = ısSuccess;
			Message = message;
		}
	}
}
