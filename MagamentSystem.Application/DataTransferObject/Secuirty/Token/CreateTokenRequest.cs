﻿namespace MagamentSystem.Application.DataTransferObject.Token
{
	public class CreateTokenRequest
	{
		public string Name { get; set; }
		public string Email { get; set; }
		public string PhoneNumber { get; set; }
		public string Address { get; set; }
		public string Password { get; set; }
	}
}
