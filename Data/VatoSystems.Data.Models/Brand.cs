namespace VatoSystems.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using VatoSystems.Data.Common.Models;

    using static VatoSystems.Common.GlobalConstants.Brand;

    public class Brand : BaseDeletableModel<int>
    {
        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; }

        [MaxLength(DescriptionMaxLength)]
        public string Desccription { get; set; }

        public int? Discount { get; set; }

        public int Rating { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [Required]
        public virtual Category Category { get; set; }

        public virtual ICollection<Model> Models { get; set; }
    }
}