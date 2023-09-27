namespace VatoSystems.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using VatoSystems.Data.Common.Models;
    using VatoSystems.Data.Models.Enums;

    public class Card : BaseDeletableModel<Guid>
    {
        [Required]
        public Guid Number { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int CVV { get; set; }

        [Required]
        public CardType Type { get; set; }

        public bool IsValid { get; set; }

        [Required]
        public string HolderName { get; set; }

        [Required]
        public string Expiration { get; set; }

        public virtual ICollection<ApplicationUser> ApplicationUsers { get; set; }
    }
}
