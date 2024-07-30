namespace MagamentSystem.Application.DataTransferObject.Buy.Sue
{
	public class CreateSueRequest
	{
		public int SueNumber { get; set; }
		public int SueTypeNumber { get; set; }
		public bool SurStatus { get; set; }
		public int AppUserId { get; set; }
		public int SueDetailsId { get; set; }
        public int AddedBy { get; set; }
        public bool IsStatus { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
