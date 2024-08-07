﻿namespace ManagamentSystem.Core.Entities.Wares
{
	public class Product : BaseEntity
	{
        public string Name	 { get; set; }
        public string Brand { get; set; }
        public decimal Price { get; set; }
        public DateTime? ProductionDate { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public bool IsUsedProduct { get; set; }
        public int CategoryId { get; set; }
        public int ProducerId { get; set; }
        public int DealerId { get; set; }
        public int MarketPlaceId { get; set; }


		public Category Category { get; set; }
		public Producer Producer { get; set; }
		public Dealer Dealer { get; set; }
		public MarketPlace Marketplace { get; set; }

	}
}
