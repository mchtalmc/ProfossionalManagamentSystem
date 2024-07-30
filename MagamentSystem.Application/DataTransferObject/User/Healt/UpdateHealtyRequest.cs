﻿namespace MagamentSystem.Application.DataTransferObject.User.Healt
{
	public class UpdateHealtyRequest
	{
        public int Id { get; set; }
		public bool HaveADisase { get; set; }
		public string WhatDiesase { get; set; }
		public bool DisabilityStatus { get; set; }
		public string WhatSidability { get; set; }
		public bool CanUseVehicle { get; set; }
		//public int UserId { get; set; }
        public int ModifiedBy { get; set; }
        public bool IsStatus { get; set; }
        public DateTime ModifiedDate { get; set; } = DateTime.UtcNow;
    }
}
