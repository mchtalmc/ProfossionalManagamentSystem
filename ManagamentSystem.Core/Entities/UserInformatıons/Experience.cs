namespace ManagamentSystem.Core.Entities.UserInformatıons
{
	public class Experience : BaseEntity
	{
        public int HowManyYear { get; set; }
        public string HowFieldWork { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string WhichTitle { get; set; }
		public AppUser AppUser { get; set; }

    }   
}
