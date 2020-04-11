using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Landlord_project.Data.Mappings
{
    public class TenantMap : IEntityTypeConfiguration<Tenant>
    {
        public void Configure(EntityTypeBuilder<Tenant> builder)
        {
            builder.HasKey(te => te.Id);
            builder.Property(te => te.Salary).HasColumnType("decimal(7, 2)");
            builder.HasMany(te => te.ResidenceAssignments).WithOne(rea => rea.Tenant).HasForeignKey(rea => rea.TenantID);
        }
    }
}
