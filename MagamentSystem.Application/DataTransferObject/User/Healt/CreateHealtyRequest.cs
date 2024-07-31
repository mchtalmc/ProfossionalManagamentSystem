namespace MagamentSystem.Application.DataTransferObject.User.Healt
{
	public class CreateHealtyRequest
	{
		public bool HaveADisase { get; set; }
		public string WhatDiesase { get; set; }
		public bool DisabilityStatus { get; set; }
		public string WhatSidability { get; set; }
		public bool CanUseVehicle { get; set; }
		public int AppUserId { get; set; }
        public int AddedBy { get; set; }
        public bool IsStatus { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    }
}
