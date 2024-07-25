namespace MagamentSystem.Application.DataTransferObject.User.Healt
{
	public class RemoveHealtyRequest
	{
        public int Id { get; set; }
        public int RemovedBy { get; set; }
        public DateTime RemovedDate { get; set; }
    }
}
