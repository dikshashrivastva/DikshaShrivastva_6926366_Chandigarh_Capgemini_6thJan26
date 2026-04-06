using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartHealthcare.Models.Entities;

namespace SmartHealthcare.API.Configurations;

public class BillConfiguration : IEntityTypeConfiguration<Bill>
{
    public void Configure(EntityTypeBuilder<Bill> builder)
    {
        builder.HasKey(b => b.Id);

        builder.HasOne(b => b.Appointment)
               .WithOne()
               .HasForeignKey<Bill>(b => b.AppointmentId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.Property(b => b.PaymentStatus)
               .HasDefaultValue("Unpaid");
    }
}