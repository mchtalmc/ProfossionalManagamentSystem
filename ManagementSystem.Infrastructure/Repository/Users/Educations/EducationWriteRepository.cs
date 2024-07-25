using MagamentSystem.Application.Repository.UserRepository.Educations;
using ManagamentSystem.Core.Entities.UserInformatıons;

namespace ManagementSystem.Infrastructure.Repository.Users.Educations
{
	public class EducationWriteRepository : WriteRepository<EducationStatus>, IEducationWriteRepository
	{
		public EducationWriteRepository(ManagamentContext context) : base(context)
		{
		}
	}
}
