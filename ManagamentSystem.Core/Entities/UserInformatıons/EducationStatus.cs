namespace ManagamentSystem.Core.Entities.UserInformatıons
{
	public class EducationStatus : BaseEntity
	{
        public string Department { get; set; }
        public string  GraduatedSchool { get; set; }
        public int GraduationScore { get; set; }
        public DateTime YearOfGraduation { get; set; }
        public int UserId { get; set; }
        public AppUser AppUser { get; set; }
        
    }
}
