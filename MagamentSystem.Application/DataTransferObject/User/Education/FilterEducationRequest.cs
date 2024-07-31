namespace MagamentSystem.Application.DataTransferObject.User.Education
{
	public class FilterEducationRequest
	{
		public string? Department { get; set; }
		public string? GraduatedSchool { get; set; }
		public DateTime? YearOfGraduation { get; set; }
		public int? AppUserId { get; set; }
	}
}
