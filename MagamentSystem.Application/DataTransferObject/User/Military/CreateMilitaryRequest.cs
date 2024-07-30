namespace MagamentSystem.Application.DataTransferObject.User.Military
{
	public class CreateMilitaryRequest
	{
		public bool IsDone { get; set; }
		public bool Delay { get; set; }
		public DateTime DelayEndDate { get; set; }
		public DateTime EndDate { get; set; }
		//public int UserId { get; set; }
        public int AddedBy { get; set; }
        public bool IsStatus { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
