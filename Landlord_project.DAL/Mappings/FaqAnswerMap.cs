using Landlord_project.Shared.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Landlord_project.DAL.Mappings
{
    public class FaqAnswerMap : IEntityTypeConfiguration<FaqAnswer>
    {
        public void Configure(EntityTypeBuilder<FaqAnswer> builder)
        {
            builder.HasKey(answer => answer.Id);
            builder.Property(answer => answer.Answer);
        }
    }
}
