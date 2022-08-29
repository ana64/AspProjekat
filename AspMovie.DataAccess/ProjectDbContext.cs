using AspMovie.Domain;
using AspMovie.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace AspMovie.DataAccess
{
    public class ProjectDbContext : DbContext
    {


        public ProjectDbContext(DbContextOptions options = null) : base(options) { }

        //public ProjectDbContext()
        //{

        //}
        public IApplicationUser User { get; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);

            modelBuilder.Entity<ActorMovie>().Property(x => x.Role).HasMaxLength(30).IsRequired();
            modelBuilder.Entity<ActorMovie>().HasKey(x => new {x.MovieId,x.ActorId});
            modelBuilder.Entity<UserUseCase>().HasKey(x => new { x.UserId, x.UseCaseId });
            modelBuilder.Entity<CrewMovie>().HasKey(x => new {x.JobId,x.CrewId,x.MovieId});
            modelBuilder.Entity<Rating>().HasKey(x => new { x.UserId, x.MovieId });
            modelBuilder.Entity<Rating>().Property(x => x.Star).HasMaxLength(2).IsRequired();



            base.OnModelCreating(modelBuilder);
        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(@"Data Source=.\SQLEXPRESS;Initial Catalog=AspMovie;Integrated Security=True")
        //        .UseLazyLoadingProxies();
        //}

        public override int SaveChanges()
        {
            foreach (var entry in this.ChangeTracker.Entries())
            {
                if (entry.Entity is Entity e)
                {
                    switch (entry.State)
                    {
                        case EntityState.Added:
                            e.IsActive = true;
                            e.CreatedAt = DateTime.UtcNow;
                            break;
                        case EntityState.Modified:
                            e.UpdatedAt = DateTime.UtcNow;
                            e.UpdatedBy = User?.Identity;
                            break;
                    }
                }
            }

            return base.SaveChanges();
        }

        public DbSet<Genre> Genres { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Actor> Actors { get; set; } 
        public DbSet<ActorMovie> ActorMovies { get; set; }
        public DbSet<Crew> Crews { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<CrewMovie> CrewMovies { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserUseCase> UserUseCases { get; set; }
        public DbSet<Certification> Certifications { get; set; }
        public DbSet<Rating> Ratings { get;set; }

    }
}
