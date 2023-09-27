// ReSharper disable VirtualMemberCallInConstructor

namespace VatoSystems.Data.Models
{
    using System;
    using System.Collections.Generic;

    using Microsoft.AspNetCore.Identity;

    using VatoSystems.Data.Common.Models;

    public class ApplicationUser : IdentityUser, IAuditInfo, IDeletableEntity
    {
        public ApplicationUser()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Roles = new HashSet<IdentityUserRole<string>>();
            this.Claims = new HashSet<IdentityUserClaim<string>>();
            this.Logins = new HashSet<IdentityUserLogin<string>>();
        }

        // Audit info
        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        // Deletable entity
        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public bool IsCompany { get; set; }

        public string CompanyName { get; set; }

        public string ShipCountry { get; set; }

        public string ShipCity { get; set; }

        public string ShipAddress1 { get; set; }

        public string ShipAddress2 { get; set; }

        public int PostalCode { get; set; }

        public virtual ICollection<IdentityUserRole<string>> Roles { get; set; }

        public virtual ICollection<IdentityUserClaim<string>> Claims { get; set; }

        public virtual ICollection<IdentityUserLogin<string>> Logins { get; set; }

        public virtual ICollection<Order> Orders { get; set; }

        public virtual ICollection<Card> Cards { get; set; }

        public virtual ICollection<Product> Products { get; set; }

        public virtual ICollection<Model> Models { get; set; }
    }
}
