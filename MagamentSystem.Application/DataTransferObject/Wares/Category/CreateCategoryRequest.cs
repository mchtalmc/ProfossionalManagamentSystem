namespace MagamentSystem.Application.DataTransferObject.Wares.Category
{
	public class CreateCategoryRequest
	{
		public string Name { get; set; }
        public int AddedBy { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
