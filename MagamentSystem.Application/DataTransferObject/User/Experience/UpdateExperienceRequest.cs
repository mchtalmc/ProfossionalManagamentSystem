namespace MagamentSystem.Application.DataTransferObject.User.Experience
{
	public class UpdateExperienceRequest
	{
        public int Id { get; set; }
		public int HowManyYear { get; set; }
		public string HowFieldWork { get; set; }
		public string City { get; set; }
		public string Country { get; set; }
		public string WhichTitle { get; set; }
		public int UserId { get; set; }
        public int ModifiedBy { get; set; }
		public DateTime ModifiedDate { get; set; }
	}
}
