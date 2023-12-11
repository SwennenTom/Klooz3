using Klooz3.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Klooz3.Data
{
	public class ApplicationDbContext : IdentityDbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options)
		{
		}

        public DbSet<Categories>? categories { get; set; }
		public DbSet<Experiment>? experiments { get; set; }
		public DbSet<Partner>? partners { get; set; }
		public DbSet<TeamRegie>? teamregies { get; set; }
		public DbSet<UserExperimenten>? userexperimenten { get; set;}
		public DbSet<ApplicationUser>? applicationuser { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure cascade delete for the relationship between Experiment and UserExperimenten
            modelBuilder.Entity<UserExperimenten>()
                .HasOne(ue => ue.Experiment)
                .WithMany(e => e.UserExperimenten)
                .OnDelete(DeleteBehavior.Cascade);
        }

    }
}