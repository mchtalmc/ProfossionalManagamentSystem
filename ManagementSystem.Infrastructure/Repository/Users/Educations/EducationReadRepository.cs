using MagamentSystem.Application.Repository.UserRepository.Educations;
using ManagamentSystem.Core.Entities.UserInformatıons;

namespace ManagementSystem.Infrastructure.Repository.Users.Educations
{
	public class EducationReadRepository : ReadRepository<EducationStatus>, IEducationReadRepository
	{
		public EducationReadRepository(ManagamentContext context) : base(context)
		{
		}
	}
}
