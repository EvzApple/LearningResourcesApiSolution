using Microsoft.EntityFrameworkCore;

namespace LearningResourcesApi.Data
{
    public class LearningResourcesDataContext :DbContext 
    {
        public LearningResourcesDataContext(
            DbContextOptions<LearningResourcesDataContext> options): base(options)
        {

        }
        public DbSet<LearningResource> LearningResources { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LearningResource>()
                .Property(p => p.Title).HasMaxLength(100);  
        } 
    }
}
