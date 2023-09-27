namespace VatoSystems.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using VatoSystems.Data.Common.Models;

    using static VatoSystems.Common.GlobalConstants.Product;

    public class Product : BaseDeletableModel<Guid>
    {
        [Required]
        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; }

        [Required]
        public int SerialNumber { get; set; }

        public decimal? Price { get; set; }

        public int? Quantity { get; set; }

        [Required]
        public bool IsAvailable { get; set; }

        public int? Discount { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [Required]
        public virtual Category Category { get; set; }

        public string ApplicationUserId { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }

        public virtual ICollection<Image> Images { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
