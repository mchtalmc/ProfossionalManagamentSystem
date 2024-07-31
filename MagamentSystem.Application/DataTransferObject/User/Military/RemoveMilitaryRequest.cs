using System.Text.Json.Serialization;

namespace MagamentSystem.Application.DataTransferObject.User.Military
{
	public class RemoveMilitaryRequest
	{
        public int Id { get; set; }
        [JsonIgnore]
        public int RemovedBy { get; set; }
        [JsonIgnore]
        public DateTime RemovedDate { get; set; } = DateTime.UtcNow;
    }
}
