namespace MagamentSystem.Application.DataTransferObject.User.Military
{
	public class UpdateMilitaryRequest
	{
		public int Id { get; set; }
		public bool IsDone { get; set; }
		public bool Delay { get; set; }
		public DateTime DelayEndDate { get; set; }
		public DateTime EndDate { get; set; }
		//public int UserId { get; set; }
        public int ModifiedBy { get; set; }
        public bool IsStatus { get; set; }
        public DateTime ModifiedDate { get; set; } = DateTime.UtcNow;
    }
}
