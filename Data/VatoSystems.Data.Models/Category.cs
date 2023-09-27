namespace VatoSystems.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using VatoSystems.Data.Common.Models;

    using static VatoSystems.Common.GlobalConstants.Category;

    public class Category : BaseDeletableModel<int>
    {
        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; }

        [Required]
        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; }

        [Required]
        public Guid ImageId { get; set; }

        [Required]
        public virtual Image Image { get; set; }

        public virtual ICollection<Brand> Brand { get; set; }
    }
}