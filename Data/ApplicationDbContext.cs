using ETickets.Models;
using Microsoft.EntityFrameworkCore;

namespace ETickets.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Cinema> Cinemas { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<ActorMovie> ActorMovies { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer("Data Source=LAPTOP-K1HI8GRN\\SQLEXPRESS;Initial Catalog=ETicketsDB;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Configure relationships and other model settings here if needed
            modelBuilder.Entity<Movie>()
                 .HasOne(m => m.Cinema)
                 .WithMany(c => c.Movies)
                 .HasForeignKey(m => m.CinemaId);
            modelBuilder.Entity<Movie>()
                .HasOne(m => m.Category)
                .WithMany(c => c.Movies)
                .HasForeignKey(m => m.CategoryId);

            modelBuilder.Entity<ActorMovie>()
                .HasKey(am => new { am.ActorId, am.MovieId });
            modelBuilder.Entity<ActorMovie>()
                .HasOne(am => am.Actor)
                .WithMany(a => a.ActorMovies)
                .HasForeignKey(am => am.ActorId);
            modelBuilder.Entity<ActorMovie>()
                .HasOne(am => am.Movie)
                .WithMany(m => m.ActorMovies)
                .HasForeignKey(am => am.MovieId);



        }
    }

}
