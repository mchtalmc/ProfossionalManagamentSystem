namespace MagamentSystem.Application.DataTransferObject.User.Military
{
	public class MilitaryResponse
	{
		public int Id { get; set; }
		public bool IsDone { get; set; }
		public bool Delay { get; set; }
		public DateTime DelayEndDate { get; set; }
		public DateTime EndDate { get; set; }
		public int UserId { get; set; }
		public int AddedBy { get; set; }
		public int ModifiedBy { get; set; }
        public int RemovedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public DateTime RemovedDate { get; set; }
    }
}
