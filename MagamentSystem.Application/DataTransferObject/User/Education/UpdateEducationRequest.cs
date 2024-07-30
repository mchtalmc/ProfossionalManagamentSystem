namespace MagamentSystem.Application.DataTransferObject.User.Education
{
	public class UpdateEducationRequest
	{
        public int Id { get; set; }
		public string Department { get; set; }
		public string GraduatedSchool { get; set; }
		public int GraduationScore { get; set; }
		public DateTime YearOfGraduation { get; set; }
		//public int UserId { get; set; }
        public int ModifiedBy { get; set; }
        public bool IsStatus { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
