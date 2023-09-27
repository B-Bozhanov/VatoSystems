namespace VatoSystems.Data.Models
{
    using System;
    using System.Collections.Generic;

    using VatoSystems.Data.Common.Models;

    public class Shipper : BaseDeletableModel<Guid>
    {
        public string Name { get; set; }

        public string PhoneNumber { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
