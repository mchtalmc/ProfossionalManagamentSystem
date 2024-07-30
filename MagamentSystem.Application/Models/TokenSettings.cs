namespace MagamentSystem.Application.Models
{
	public class TokenSettings
	{
		public string ValidAudience { get; set; }
		public string ValidIssuer { get; set; }
		public string Secret { get; set; }
		public int TokenValidityInMunites { get; set; }
		public int RefreshTokenValidtyInDays { get; set; }
	}


}
