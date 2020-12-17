
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Landlord_project.Data.Mappings
{
    public class FaqCategoryMap : IEntityTypeConfiguration<FaqCategory>
    {
        public void Configure(EntityTypeBuilder<FaqCategory> builder)
        {
            builder.HasKey(fc => fc.Id);
            builder.Property(fc => fc.Name);
        }
    }
}
