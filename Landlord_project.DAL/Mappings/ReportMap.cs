﻿using Landlord_project.Shared.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Landlord_project.DAL.Mappings
{
    public class ReportMap : IEntityTypeConfiguration<ResidenceReport>
    {
        public void Configure(EntityTypeBuilder<ResidenceReport> builder)
        {
            builder.HasOne(re => re.Residence)
                .WithMany(rep => rep.ResidenceReports)
                .HasForeignKey(b => b.ResidenceId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
