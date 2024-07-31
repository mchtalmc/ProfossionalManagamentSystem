namespace MagamentSystem.Application.DataTransferObject.User.Experience
{
	public class FilterExperienceRequest
	{
		public string? City { get; set; }
		public string? Country { get; set; }
		public string? WhichTitle { get; set; }
		public int? AppUserId { get; set; }
	}
}
