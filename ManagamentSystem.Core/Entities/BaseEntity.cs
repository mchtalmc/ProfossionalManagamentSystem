namespace ManagamentSystem.Core.Entities
{
    public class BaseEntity : BaseEntity<int>
    {
    }
    public class BaseEntity<T>
    {
        public T Id { get; set; }
        public int AddedBy { get; set; }
        public int? ModifiedBy { get; set; }
        public int? RemovedBy { get; set; }
        public bool IsStatus { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public DateTime? RemovedDate { get; set; }
    }
}
