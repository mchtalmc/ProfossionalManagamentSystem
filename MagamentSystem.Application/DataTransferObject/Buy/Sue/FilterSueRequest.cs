namespace MagamentSystem.Application.DataTransferObject.Buy.Sue
{
	public class FilterSueRequest
	{
		public bool? SurStatus { get; set; }
		public int? AppUserId { get; set; }
		public int? SueDetailsId { get; set; }
	}
}
