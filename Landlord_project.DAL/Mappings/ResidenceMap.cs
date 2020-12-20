using Landlord_project.Shared.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Landlord_project.DAL.Mappings
{
    public class ResidenceMap : IEntityTypeConfiguration<Residence>
    {
        public void Configure(EntityTypeBuilder<Residence> builder)
        {
            builder.HasKey(re => re.Id);
            builder.Property(re => re.RentalPrice).HasColumnType("decimal(6, 2)");
            builder.HasMany(re => re.ResidenceAssignments).WithOne(rea => rea.Residence).HasForeignKey(rea => rea.ResidenceID);

            builder.ToTable("Residence");
        }
    }
}
