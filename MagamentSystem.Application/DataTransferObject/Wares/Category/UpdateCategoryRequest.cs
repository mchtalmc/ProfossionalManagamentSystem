namespace MagamentSystem.Application.DataTransferObject.Wares.Category
{
	public class UpdateCategoryRequest
	{
        public int Id { get; set; }
		public string? Name { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
		public bool IsStatus { get; set; }
	}
}
