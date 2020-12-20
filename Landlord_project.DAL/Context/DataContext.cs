using Landlord_project.DAL.Mappings;
using Landlord_project.Shared.Domain;
using Microsoft.EntityFrameworkCore;

namespace Landlord_project.DAL
{
    public class DataContext : DbContext
    {
        #region Constructor
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }
        #endregion

        #region Tables
        public DbSet<Residence> Residences { get; set; }
        public DbSet<Tenant> Tenants { get; set; }
        public DbSet<ResidenceAssignment> ResidenceAssignments { get; set; }
        public DbSet<ResidenceReport> ResidenceReports { get; set; }
        public DbSet<ResidenceApplication> ResidenceApplications { get; set; }
        public DbSet<FaqCategory> FaqCategories { get; set; }
        public DbSet<FaqQuestion> FaqQuestions { get; set; }

        public DbSet<FaqAnswer> FaqAnswers { get; set; }

        #endregion

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new ResidenceMap());
            builder.ApplyConfiguration(new TenantMap());
            builder.ApplyConfiguration(new ResidenceAssignmentMap());
            builder.ApplyConfiguration(new ReportMap());

            builder.ApplyConfiguration(new FaqCategoryMap());
            builder.ApplyConfiguration(new FaqQuestionMap());
            builder.ApplyConfiguration(new FaqAnswerMap());

            // Residence Application
        }
    }
}
