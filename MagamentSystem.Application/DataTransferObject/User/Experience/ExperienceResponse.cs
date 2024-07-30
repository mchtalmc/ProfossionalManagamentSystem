namespace MagamentSystem.Application.DataTransferObject.User.Experience
{
	public class ExperienceResponse
	{
		public int Id { get; set; }
		public int HowManyYear { get; set; }
		public string HowFieldWork { get; set; }
		public string City { get; set; }
		public string Country { get; set; }
		public string WhichTitle { get; set; }
	//	public int UserId { get; set; }
		public int AddedBy { get; set; }
		public int? ModifiedBy { get; set; }
        public int? RemovedBy { get; set; }
        public bool IsStatus { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
		public DateTime? RemovedDate { get; set; }
	}
}
