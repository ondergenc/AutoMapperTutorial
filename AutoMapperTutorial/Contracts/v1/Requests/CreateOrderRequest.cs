using System;
using System.Collections.Generic;

namespace AutoMapperTutorial.Contracts.v1.Requests
{
    public class CreateOrderRequest
    {
        public int CustomerId { get; set; }
        public List<CreateOrderItemRequest> OrderItems { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
