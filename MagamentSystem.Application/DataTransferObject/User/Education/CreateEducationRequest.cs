namespace MagamentSystem.Application.DataTransferObject.User.Education
{
	public class CreateEducationRequest
	{
		public string Department { get; set; }
		public string GraduatedSchool { get; set; }
		public int GraduationScore { get; set; }
		public DateTime YearOfGraduation { get; set; }
		public int AppUserId { get; set; }
        public int AddedBy { get; set; }
        public bool IsStatus { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
