namespace MagamentSystem.Application.DataTransferObject.User.Education
{
	public class EducationResponse
	{
		public int Id { get; set; }
		public string Department { get; set; }
		public string GraduatedSchool { get; set; }
		public int GraduationScore { get; set; }
		public DateTime YearOfGraduation { get; set; }
		//public int UserId { get; set; }
		public int AddedBy { get; set; }
		public int? ModifiedBy { get; set; }
        public int? RemovedBy { get; set; }
        public bool IsStatus { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? RemovedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
	}
}
