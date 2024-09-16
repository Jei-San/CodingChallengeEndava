using CodingChallengeEndava.Core.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace CodingChallengeEndava.Core.Data
{
    public class CodingChallengeEndavaDbContext : DbContext
    {
        public CodingChallengeEndavaDbContext(DbContextOptions<CodingChallengeEndavaDbContext> options)
            : base(options)
        { }

        public DbSet<Story> Stories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Story>(entity =>
            {
                entity.HasKey(x => x.Id);
                entity.Property(x => x.Title).HasMaxLength(255).IsRequired();
                entity.Property(x => x.Url).HasMaxLength(255).IsRequired();
                entity.Property(x => x.ExternalId).IsRequired();
                entity.Property(x => x.Time).IsRequired(false);
                entity.Property(x => x.Score).IsRequired(false);
                entity.Property(x => x.Descendants).IsRequired(false);
                entity.Property(x => x.Type).IsRequired(false);
                entity.Property(x => x.By).IsRequired(false);
                entity.Property(x => x.Kids).IsRequired(false);

                entity.HasIndex(x => x.Id);
                entity.HasIndex(x => new { x.Title, x.ExternalId });
                entity.HasIndex(x => x.ExternalId);
            });
        }
    }
}
