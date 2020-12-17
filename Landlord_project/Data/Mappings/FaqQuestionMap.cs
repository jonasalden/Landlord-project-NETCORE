using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Landlord_project.Data.Mappings
{
    public class FaqQuestionMap : IEntityTypeConfiguration<FaqQuestion>
    {
        public void Configure(EntityTypeBuilder<FaqQuestion> builder)
        {
            builder.Property(fq => fq.Title);

            builder.HasOne(fq => fq.Category)
                .WithOne(fc => fc.Question)
                .HasForeignKey<FaqQuestion>(fq => fq.CategoryId);

            builder.HasOne(fq => fq.Answer)
          .WithOne(fc => fc.Question)
          .HasForeignKey<FaqQuestion>(fq => fq.AnswerId);

        }
    }
}
