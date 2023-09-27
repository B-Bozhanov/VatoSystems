namespace VatoSystems.Data.Models
{
    using System;

    public class OrderDetail
    {
        public Guid OrderId { get; set; }

        public virtual Order Order { get; set; }

        public Guid ProductId { get; set; }

        public virtual Product Product { get; set; }

        public int OrderNumber { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public int Discount { get; set; }

        public decimal TotalPrice { get; set; }
    }
}