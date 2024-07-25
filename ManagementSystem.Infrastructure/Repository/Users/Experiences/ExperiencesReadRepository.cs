using MagamentSystem.Application.Repository.UserRepository.Experiences;
using ManagamentSystem.Core.Entities.UserInformatıons;

namespace ManagementSystem.Infrastructure.Repository.Users.Experiences
{
	public class ExperiencesReadRepository : ReadRepository<Experience>, IExperienceReadRepository
	{
		public ExperiencesReadRepository(ManagamentContext context) : base(context)
		{
		}
	}
}
