using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using Vicky.EntityConfigurations;

namespace Vicky.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Series> Series { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Genre>  Genres { get; set; }
        public DbSet<Season> Seasons{ get; set; }
        public DbSet<Episode> Episodes { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {

        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Movie Configurations
            modelBuilder.Configurations.Add( new MovieConfiguration());
            modelBuilder.Configurations.Add(new GenreConfiguration());
            modelBuilder.Configurations.Add(new SeriesConfigurations());


            base.OnModelCreating(modelBuilder);
        }
    }
}