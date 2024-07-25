namespace ManagamentSystem.Core.Entities.Buy
{
	public class Sue : BaseEntity
	{
     
        public int SueNumber { get; set; }
		public int SueTypeNumber { get; set; }
		public bool SurStatus { get; set; }
		public int AppUserId { get; set; }
		public int SueDetailsId { get; set; }
		public SueDetails SueDetails { get; set; }
        public AppUser AppUser { get; set; }
     


    }
}
