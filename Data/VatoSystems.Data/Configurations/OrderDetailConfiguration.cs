namespace VatoSystems.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using VatoSystems.Data.Models;

    public class OrderDetailConfiguration : IEntityTypeConfiguration<OrderDetail>
    {
        public void Configure(EntityTypeBuilder<OrderDetail> orderDetail)
        {
            orderDetail.HasKey(e => new { e.OrderId, e.ProductId });
        }
    }
}
