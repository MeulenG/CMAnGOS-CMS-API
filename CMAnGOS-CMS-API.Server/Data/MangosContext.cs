using Microsoft.EntityFrameworkCore;
using CMAnGOS_CMS_API.Server.Models.Mangos;

namespace CMAnGOS_CMS_API.Server.Data
{
    public class MangosContext : DbContext
    {
        public MangosContext(DbContextOptions<MangosContext> options) : base(options)
        {
        }

        public DbSet<ItemTemplate> ItemTemplates { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ItemTemplate>()
                .HasKey(it => it.Entry);
        }
    }
}
