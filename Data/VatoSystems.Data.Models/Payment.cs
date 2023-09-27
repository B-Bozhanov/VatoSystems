namespace VatoSystems.Data.Models
{
    using System;
    using System.Collections.Generic;

    using VatoSystems.Data.Common.Models;
    using VatoSystems.Data.Models.Enums;

    public class Payment : BaseDeletableModel<Guid>
    {
        public PaymentType Type { get; set; }

        public bool IsPayed { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
