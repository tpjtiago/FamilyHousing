using FamilyHousing.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FamilyHousing.Data.Contexts
{
    public class FamilyContext : DbContext
    {
        public FamilyContext(DbContextOptions options)
            : base(options) { }

        public DbSet<Family> Families { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(FamilyContext).Assembly);
        }

    }
}
