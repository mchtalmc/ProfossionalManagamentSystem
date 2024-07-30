namespace MagamentSystem.Application.DataTransferObject.Wares.Producer
{
	public class UpdateProducerRequest
	{
        public int Id { get; set; }
		public string Name { get; set; }
		public string Location { get; set; }
		public string PhoneNumber { get; set; }
		public string Email { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool IsStatus { get; set; }
    }
}
