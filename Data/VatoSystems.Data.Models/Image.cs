namespace VatoSystems.Data.Models
{
    using System;

    using VatoSystems.Data.Common.Models;

    public class Image : BaseDeletableModel<Guid>
    {
        public double Size { get; set; }

        public string Extencion { get; set; }

        public Guid? ProductId { get; set; }

        public virtual Product Product { get; set; }
    }
}
