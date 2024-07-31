namespace ManagamentSystem.Core.Entities.UserInformatıons
{
	public class EducationStatus : BaseEntity
	{
        public string Department { get; set; }
        public string  GraduatedSchool { get; set; }
        public int GraduationScore { get; set; }
        public int AppUserId { get; set; }
        public DateTime YearOfGraduation { get; set; }
		public AppUser AppUser { get; set; }
        
    }
}
