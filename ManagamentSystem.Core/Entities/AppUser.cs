using ManagamentSystem.Core.Entities.CustomIdentity;
using ManagamentSystem.Core.Entities.UserInformatıons;

namespace ManagamentSystem.Core.Entities
{
	public class AppUser :  BaseEntity
	{
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Password { get; set; }
        public bool IsBlocked { get; set; }
        public string Title { get; set; }
        public bool Gender { get; set; }
        public ICollection<HealthStatus>     HealthStatuses { get; set; }
        public ICollection<Experience> Experiences { get; set; }
        public ICollection<EducationStatus> EducationStatuses { get; set; }
        public ICollection<UserPermission>       UserPermissions { get; set; }
        





    }
}
