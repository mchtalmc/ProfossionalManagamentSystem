namespace ManagamentSystem.Core.Entities.CustomIdentity
{
	public	 class CustomRole :BaseEntity
	{
       
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<RolePermission> RolePermissions { get; set; }
    }
}
