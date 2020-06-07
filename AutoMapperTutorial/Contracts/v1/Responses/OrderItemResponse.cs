namespace AutoMapperTutorial.Contracts.v1.Responses
{
    public class OrderItemResponse
    {
        public int OrderItemId { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public ProductResponse Product { get; set; }
        public int Quantity { get; set; }
    }
}
