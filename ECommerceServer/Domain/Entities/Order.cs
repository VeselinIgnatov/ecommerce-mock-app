namespace Domain.Entities
{
    public class Order : IOrder
    {
        public Guid Id { get; set; }
        public List<Product> Products { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime AddedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public Guid AddeddBy { get; set; }
        public Guid ModifiedBy { get; set; }
    }
}
