﻿namespace MagamentSystem.Application.DataTransferObject.Buy.Contractor
{
	public class ContractorResponse
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string ContractorCode { get; set; }
		public string Address { get; set; }
		public string PhoneNumber { get; set; }
		public string Email { get; set; }
		public int SueDetailsId { get; set; }
        public int AddedBy { get; set; }
        public int? ModifiedBy { get; set; }
        public int? RemovedBy { get; set; }
        public bool IsStatus { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public DateTime? RemovedDate { get; set; }
    }
}
