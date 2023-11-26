using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace TP3.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Movie>? movies { get; set; }
        public DbSet<Genre>? genres { get; set; }

        public DbSet<Customer>? custumors { get; set; }
        public DbSet<Membershiptype>? Membershiptypes { get; set; }

        protected override void OnModelCreating(ModelBuilder model)
        {

            base.OnModelCreating(model);
            string GenreJSon = System.IO.File.ReadAllText("GenreSeedData.Json");
            List<Genre>? genres = System.Text.Json.JsonSerializer.Deserialize<List<Genre>>(GenreJSon);
            //Seed to categorie
            foreach (Genre c in genres)
                model.Entity<Genre>().HasData(c);
        }

    }
}
