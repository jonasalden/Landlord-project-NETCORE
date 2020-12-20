using Landlord_project.Shared.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Landlord_project.DAL.Mappings
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
