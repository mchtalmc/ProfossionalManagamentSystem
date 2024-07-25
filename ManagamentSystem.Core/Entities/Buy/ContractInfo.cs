namespace ManagamentSystem.Core.Entities.Buy
{
	public class ContractInfo : BaseEntity
	{
        public string ContractName { get; set; }
        public string ContractNo { get; set; }
        public DateTime StartedDate { get; set; }
        public DateTime EndDate { get; set; }
        public int ContractAmount { get; set; }
        public string Currency { get; set; }
        public int SueDetailsId { get; set; }
        public SueDetails SueDetails { get; set; }
       
    }
}
