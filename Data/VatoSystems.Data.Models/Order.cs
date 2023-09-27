namespace VatoSystems.Data.Models
{
    using System;
    using System.Collections.Generic;

    using VatoSystems.Data.Common.Models;
    using VatoSystems.Data.Models.Enums;

    public class Order : BaseDeletableModel<Guid>
    {
        public int Number { get; set; }

        public OrderStatus Status { get; set; }

        public DateTime ShipDate { get; set; }

        public Guid PaymentId { get; set; }

        public virtual Payment Payment { get; set; }

        public string ApplicationUserId { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }

        public Guid ShipperId { get; set; }

        public virtual Shipper Shipper { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
