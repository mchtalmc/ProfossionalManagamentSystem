namespace MagamentSystem.Application.DataTransferObject.User.Healt
{
	public class FilterHealtyRequest
	{
		public bool HaveADisase { get; set; }
		public bool DisabilityStatus { get; set; }
		public bool CanUseVehicle { get; set; }
		public int UserId { get; set; }
	}
}
