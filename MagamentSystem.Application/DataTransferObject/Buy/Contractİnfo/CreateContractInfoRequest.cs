namespace MagamentSystem.Application.DataTransferObject.Buy.Contractİnfo
{
	public class CreateContractInfoRequest
	{
		public string ContractName { get; set; }
		public string ContractNo { get; set; }
		public DateTime StartedDate { get; set; }
		public DateTime EndDate { get; set; }
		public int ContractAmount { get; set; }
		public string Currency { get; set; }
		public int SueDetailsId { get; set; }
        public int AddedBy { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
