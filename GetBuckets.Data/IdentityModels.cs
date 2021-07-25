using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace GetBuckets.Data
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }
        public class IdentityUserLoginConfiguration : EntityTypeConfiguration<IdentityUserLogin>
        {
            public IdentityUserLoginConfiguration()
            {
                HasKey(iul => iul.UserId);
            }
        }
        public class IdentityUserRoleConfiguration : EntityTypeConfiguration<IdentityUserRole>
        {
            public IdentityUserRoleConfiguration()
            {
                HasKey(iur => iur.UserId);
            }
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
        public DbSet<Player> Players { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Review> Reviews { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder
                .Conventions
                .Remove<PluralizingTableNameConvention>();

            //modelBuilder.Entity<Review>()
            //.HasOptional(p => p.Player)// can create a player profile without having a playerID in review.
            //.WithRequired(l => l.PlayerID)
            //.WillCascadeOnDelete(false);

            //modelBuilder.Entity<Location>()
            //    .HasKey(pl => pl.PlayerID);
            ////.WithRequired(s => s.);
            
            //modelBuilder.Entity<Review>() //fluent stuff adding in throwing in and definiting some parameters. The system otherwise assumes.
            //    .HasOptional(o => o.Player)
            //    //.HasMany(d => d.Player)
            //    .WithRequired(k => k.Review)
            //    .HasForeignKey(k => k.PlayerID) //calling it out the foreignkey.
            //    .WillCascadeOnDelete(false); //dont delete any of the other stuff.

            //modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();


            modelBuilder
                .Configurations
                .Add(new IdentityUserLoginConfiguration())
                .Add(new IdentityUserRoleConfiguration());
            

        }
    }
}