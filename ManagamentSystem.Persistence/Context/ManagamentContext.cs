using ManagamentSystem.Core.Entities;
using ManagamentSystem.Core.Entities.Buy;
using ManagamentSystem.Core.Entities.UserInformatıons;
using ManagamentSystem.Core.Entities.Wares;
using Microsoft.EntityFrameworkCore;

public class ManagamentContext : DbContext
{
	public ManagamentContext(DbContextOptions options) : base(options)
	{
	}



	public DbSet<AppUser> AppUsers { get; set; }
	public DbSet<ContractInfo> ContractInfos { get; set; }
	public DbSet<Contractor> Contractors { get; set; }
	public DbSet<Sue> Sues { get; set; }
	public DbSet<SueDetails> SueDetails { get; set; }
	public DbSet<Category> Categories { get; set; }
	public DbSet<Producer> Producers { get; set; }
	public DbSet<Dealer> Dealers { get; set; }
	public DbSet<Product> Products { get; set; } 
    public DbSet<EducationStatus>	 EducationStatuses { get; set; }
    public DbSet<Experience> Experiences { get; set; }
    public DbSet<HealthStatus> HealthStatuses { get; set; }
    public DbSet<MilitaryStatus> MilitaryStatuses { get; set; }
}
