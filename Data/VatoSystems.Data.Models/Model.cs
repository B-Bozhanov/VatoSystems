namespace VatoSystems.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using VatoSystems.Data.Common.Models;

    using static VatoSystems.Common.GlobalConstants.Model;

    public class Model : BaseDeletableModel<int>
    {
        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; }

        public int? Discount { get; set; }

        public int Rating { get; set; }

        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; }

        [Required]
        public int BrandId { get; set; }

        [Required]
        public virtual Brand Brand { get; set; }

        public virtual ICollection<ApplicationUser> ApplicationUsers { get; set; }
    }
}