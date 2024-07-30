namespace MagamentSystem.Application.DataTransferObject.Wares.Producer
{
	public class CreateProducerRequest
	{
		public string Name { get; set; }
		public string Location { get; set; }
		public string PhoneNumber { get; set; }
		public string Email { get; set; }
        public int AddedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsStatus { get; set; }
    }
}
