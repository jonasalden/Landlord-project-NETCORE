using Landlord_project.Data.Mappings;
using Microsoft.EntityFrameworkCore;

namespace Landlord_project.Data
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
        #endregion

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new ResidenceMap());
            builder.ApplyConfiguration(new TenantMap());
            builder.ApplyConfiguration(new ResidenceAssignmentMap());
        }
    }
}
