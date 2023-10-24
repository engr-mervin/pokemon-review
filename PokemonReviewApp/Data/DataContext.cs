using Microsoft.EntityFrameworkCore;

namespace PokemonReviewApp.Data
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options):base(options) { }


        public DbSet<Models.Category> Categories { get; set; }
        public DbSet<Models.Country> Countries { get; set; }
        public DbSet<Models.Owner> Owners { get; set; }
        public DbSet<Models.Pokemon> Pokemons { get; set; }
        public DbSet<Models.PokemonOwner> PokemonOwners { get; set; }
        public DbSet<Models.PokemonCategory> PokemonCategories { get; set; }
        public DbSet<Models.Review> Reviews { get; set; }
        public DbSet<Models.Reviewer> Reviewers { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Models.PokemonCategory>().HasKey(pc => new { pc.PokemonId, pc.CategoryId });
            modelBuilder.Entity<Models.PokemonCategory>().HasOne(p => p.Pokemon).WithMany(pc => pc.PokemonCategories).HasForeignKey(c => c.PokemonId);
            modelBuilder.Entity<Models.PokemonCategory>().HasOne(p => p.Category).WithMany(pc => pc.PokemonCategories).HasForeignKey(c => c.CategoryId);


            modelBuilder.Entity<Models.PokemonOwner>().HasKey(po => new { po.PokemonId, po.OwnerId });
            modelBuilder.Entity<Models.PokemonOwner>().HasOne(p => p.Pokemon).WithMany(po => po.PokemonOwners).HasForeignKey(c => c.PokemonId);
            modelBuilder.Entity<Models.PokemonOwner>().HasOne(p => p.Owner).WithMany(po=> po.PokemonOwners).HasForeignKey(c => c.OwnerId);



            base.OnModelCreating(modelBuilder);
        }

    }
}
