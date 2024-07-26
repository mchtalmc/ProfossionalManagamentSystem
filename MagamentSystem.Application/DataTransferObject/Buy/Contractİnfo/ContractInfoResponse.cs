namespace MagamentSystem.Application.DataTransferObject.Buy.Contractİnfo
{
	public class ContractInfoResponse
	{
		public int Id { get; set; }
		public string ContractName { get; set; }
		public string ContractNo { get; set; }
		public DateTime StartedDate { get; set; }
		public DateTime EndDate { get; set; }
		public int ContractAmount { get; set; }
		public string Currency { get; set; }
		public int SueDetailsId { get; set; }
        public int AddedBy { get; set; }
        public int? ModifiedBy { get; set; }
        public int? RemovedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public DateTime? RemovedDate { get; set; }
    }
}
