namespace ManagamentSystem.Core.Entities.UserInformatıons
{
	public class MilitaryStatus : BaseEntity
	{
        public bool IsDone { get; set; }
        public bool Delay { get; set; }
        public DateTime DelayEndDate { get; set; }
        public DateTime EndDate { get; set; }
        public AppUser AppUser { get; set; }

    }
}
