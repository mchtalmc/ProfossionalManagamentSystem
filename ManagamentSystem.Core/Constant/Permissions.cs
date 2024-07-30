namespace ManagamentSystem.Core.Constant
{
	public class Permissions
	{
		public static class ContractInfo
		{
			public const string Create = "Permissions.ContractInfo.Create";
			public const string Update = "Permissions.ContractInfo.Update";
			public const string Delete = "Permissions.ContractInfo.Delete";
			public const string Get = "Permissions.ContractInfo.Get";
			public const string AllFilter = "Permissions.ContractInfo.AllFilter";
			public const string Filter = "Permissions.ContractInfo.Filter";
		}
		public static class Contractor
		{
			public const string Create = "Permissions.Contractor.Create";
			public const string Update = "Permissions.Contractor.Update";
			public const string Delete = "Permissions.Contractor.Delete";
			public const string Get = "Permissions.Contractor.Get";
			public const string AllFilter = "Permissions.Contractor.AllFilter";
			public const string Filter = "Permissions.Contractor.Filter";
		}
		public static class Sue
		{
			public const string Create = "Permissions.Sue.Create";
			public const string Update = "Permissions.Sue.Update";
			public const string Delete = "Permissions.Sue.Delete";
			public const string Get = "Permissions.Sue.Get";
			public const string AllFilter = "Permissions.Sue.AllFilter";
			public const string Filter = "Permissions.Sue.Filter";
		}
		public static class SueDetails
		{
			public const string Create = "Permissions.SueDetails.Create";
			public const string Update = "Permissions.SueDetails.Update";
			public const string Delete = "Permissions.SueDetails.Delete";
			public const string Get = "Permissions.SueDetails.Get";
			public const string AllFilter = "Permissions.SueDetails.AllFilter";
			public const string Filter = "Permissions.SueDetails.Filter";
		}
		public static class EducationStatus
		{
			public const string Create = "Permissions.EducationStatus.Create";
			public const string Update = "Permissions.EducationStatus.Update";
			public const string Delete = "Permissions.EducationStatus.Delete";
			public const string Get = "Permissions.EducationStatus.Get";
			public const string AllFilter = "Permissions.EducationStatus.AllFilter";
			public const string Filter = "Permissions.EducationStatus.Filter";
		}
		public static class Experience
		{
			public const string Create = "Permissions.Experience.Create";
			public const string Update = "Permissions.Experience.Update";
			public const string Delete = "Permissions.Experience.Delete";
			public const string Get = "Permissions.Experience.Get";
			public const string AllFilter = "Permissions.Experience.AllFilter";
			public const string Filter = "Permissions.Experience.Filter";
		}
		public static class HealthStatus
		{
			public const string Create = "Permissions.HealthStatus.Create";
			public const string Update = "Permissions.HealthStatus.Update";
			public const string Delete = "Permissions.HealthStatus.Delete";
			public const string Get = "Permissions.HealthStatus.Get";
			public const string AllFilter = "Permissions.HealthStatus.AllFilter";
			public const string Filter = "Permissions.HealthStatus.Filter";
		}
		public static class MilitaryStatus
		{
			public const string Create = "Permissions.MilitaryStatus.Create";
			public const string Update = "Permissions.MilitaryStatus.Update";
			public const string Delete = "Permissions.MilitaryStatus.Delete";
			public const string Get = "Permissions.MilitaryStatus.Get";
			public const string AllFilter = "Permissions.MilitaryStatus.AllFilter";
			public const string Filter = "Permissions.MilitaryStatus.Filter";
		}
        public static class  Category 
        {
			public const string Create = "Permissions.Category.Create";
			public const string Update = "Permissions.Category.Update";
			public const string Delete = "Permissions.Category.Delete";
			public const string Get = "Permissions.Category.Get";
			public const string AllFilter = "Permissions.Category.AllFilter";
			public const string Filter = "Permissions.Category.Filter";
		}
		public static class Dealer
		{
			public const string Create = "Permissions.Dealer.Create";
			public const string Update = "Permissions.Dealer.Update";
			public const string Delete = "Permissions.Dealer.Delete";
			public const string Get = "Permissions.Dealer.Get";
			public const string AllFilter = "Permissions.Dealer.AllFilter";
			public const string Filter = "Permissions.Dealer.Filter";
		}
		public static class Producer
		{
			public const string Create = "Permissions.Producer.Create";
			public const string Update = "Permissions.Producer.Update";
			public const string Delete = "Permissions.Producer.Delete";
			public const string Get = "Permissions.Producer.Get";
			public const string AllFilter = "Permissions.Producer.AllFilter";
			public const string Filter = "Permissions.Producer.Filter";
		}
		public static class MarketPlace
		{
			public const string Create = "Permissions.MarketPlace.Create";
			public const string Update = "Permissions.MarketPlace.Update";
			public const string Delete = "Permissions.MarketPlace.Delete";
			public const string Get = "Permissions.MarketPlace.Get";
			public const string AllFilter = "Permissions.MarketPlace.AllFilter";
			public const string Filter = "Permissions.MarketPlace.Filter";
		}
		public static class Product
		{
			public const string Create = "Permissions.Product.Create";
			public const string Update = "Permissions.Product.Update";
			public const string Delete = "Permissions.Product.Delete";
			public const string Get = "Permissions.Product.Get";
			public const string AllFilter = "Permissions.Product.AllFilter";
			public const string Filter = "Permissions.Product.Filter";
		}
		public static class AppUser
		{
			public const string Create = "Permissions.AppUser.Create";
			public const string Update = "Permissions.AppUser.Update";
			public const string Delete = "Permissions.AppUser.Delete";
			public const string Get = "Permissions.AppUser.Get";
			public const string AllFilter = "Permissions.AppUser.AllFilter";
			public const string Filter = "Permissions.AppUser.Filter";
		}
		public static List<string> GetPermissionsRoleList(List<string>? roleList = null)
		{
			roleList ??= new List<string>();

			foreach (Type type in typeof(Permissions).GetNestedTypes())
			{
				foreach (var item in type.GetNestedTypes())
				{
					foreach (var fields in item.GetFields())
					{
						roleList.Add(fields.GetValue(type).ToString());
					};
				}
			}
			return roleList;
		}
		public static List<string> GetPermissions(List<string>? authorityList = null, List<Type>? typList = null)
		{
			authorityList ??= new List<string>();


			typList ??= typeof(Permissions).GetNestedTypes().ToList();


			foreach (Type type in typList)
			{
				if (type.GetFields().Any())
				{
					foreach (var fiels in type.GetFields())
					{
						authorityList.Add(fiels.GetValue(type).ToString());
					};
				}
				else
				{
					return GetPermissions(authorityList, type.GetNestedTypes().ToList());
				}
			}

			return authorityList;
		}
	}
}
