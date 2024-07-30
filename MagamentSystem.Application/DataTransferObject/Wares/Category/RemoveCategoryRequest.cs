using System.Text.Json.Serialization;

namespace MagamentSystem.Application.DataTransferObject.Wares.Category
{
	public class RemoveCategoryRequest
	{
        public int Id { get; set; }
        [JsonIgnore]
        public int RemovedBy { get; set; }
        public DateTime RemovedDate { get; set; }
    }
}
