namespace MagamentSystem.Application.DataTransferObject.Buy.Contractor
{
	public class CreateContractorRequest
	{
		public string Name { get; set; }
		public string ContractorCode { get; set; }
		public string Address { get; set; }
		public string PhoneNumber { get; set; }
		public string Email { get; set; }
		public int SueDetailsId { get; set; }
        public int AddedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsSuccess { get; set; }
    }
}
