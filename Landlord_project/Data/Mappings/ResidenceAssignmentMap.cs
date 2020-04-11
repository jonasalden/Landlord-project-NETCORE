using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Landlord_project.Data.Mappings
{
    public class ResidenceAssignmentMap : IEntityTypeConfiguration<ResidenceAssignment>
    {
        public void Configure(EntityTypeBuilder<ResidenceAssignment> builder)
        {
            builder.HasKey(ra => new { ra.ResidenceID, ra.TenantID });

            builder.HasOne(ra => ra.Residence)
                .WithMany(ra => ra.ResidenceAssignments)
                .HasForeignKey(k => k.ResidenceID);

            builder.HasOne(ra => ra.Tenant)
                .WithMany(m => m.ResidenceAssignments)
                .HasForeignKey(k => k.TenantID);
        }
    }
}
