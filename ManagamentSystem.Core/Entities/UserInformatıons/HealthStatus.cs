namespace ManagamentSystem.Core.Entities.UserInformatıons
{
	public class HealthStatus : BaseEntity
	{
        public bool HaveADisase { get; set; }
        public string WhatDiesase { get; set; }
        public bool DisabilityStatus { get; set; }
        public string WhatSidability { get; set; }
        public bool CanUseVehicle { get; set; }
		public AppUser AppUser { get; set; }
    }
}
