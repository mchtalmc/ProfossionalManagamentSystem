using MagamentSystem.Application.Repository.UserRepository.Experiences;
using ManagamentSystem.Core.Entities.UserInformatıons;

namespace ManagementSystem.Infrastructure.Repository.Users.Experiences
{
	public class ExperiencesWriteRepository : WriteRepository<Experience>, IExperiencesWriteRepository
	{
		public ExperiencesWriteRepository(ManagamentContext context) : base(context)
		{
		}
	}
}
