using System.Text.Json.Serialization;

namespace MagamentSystem.Application.DataTransferObject.Wares.Dealer
{
	public class RemoveDealerRequest
	{
        public int Id { get; set; }
        [JsonIgnore]
        public int RemovedBy { get; set; }
        [JsonIgnore]
        public DateTime RemovedDate { get; set; }
    }
}
