using Microsoft.EntityFrameworkCore;
using CMAnGOS_CMS_API.Server.Models.Characters;

namespace CMAnGOS_CMS_API.Server.Data
{
    public class CharactersContext : DbContext
    {
        public CharactersContext(DbContextOptions<CharactersContext> options) : base(options)
        {
        }

        public DbSet<Character> Characters { get; set; }
        public DbSet<CharacterInventory> CharacterInventories { get; set; }
        public DbSet<CharacterStats> CharacterStats { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Character>()
                .HasKey(c => c.Guid);

            modelBuilder.Entity<CharacterInventory>()
                .HasKey(ci => new { ci.Guid, ci.Bag, ci.Slot });

            modelBuilder.Entity<CharacterStats>()
                .HasKey(cs => cs.Guid);
        }
    }
}
