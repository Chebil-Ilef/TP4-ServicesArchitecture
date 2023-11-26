using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Linq;
using TP3.Models;
using TP4.Services.ServiceContracts;

namespace TP4.Services.Services
{
    public class MovieService : IMovieService
    {
        private readonly AppDbContext _db;

        public MovieService(AppDbContext db)
        {
            _db = db;
        }

        public List<Movie> GetAllMovies()
        {
            return _db.movies.ToList();
        }

        public Movie GetMovieById(int id)
        {
            return _db.movies.Find(id);
        }

        public void CreateMovie(Movie movie)
        {
            if (movie.ImageFile != null && movie.ImageFile.Length > 0)
            {
                // Save the image file on the server
                var imagePath = Path.Combine("wwwroot/images", movie.ImageFile.FileName);
                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    movie.ImageFile.CopyTo(stream);
                }

                // Save the image path in the database
                movie.Photo = $"/images/{movie.ImageFile.FileName}";
            }

            _db.movies.Add(movie);
            _db.SaveChanges();
        }

        public void Edit(Movie movie)
        {
            _db.Entry(movie).State = EntityState.Modified;
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            var movie = _db.movies.Find(id);

            if (movie != null)
            {
                _db.movies.Remove(movie);
                _db.SaveChanges();
            }
        }

        /*LINQ QUERIES*/
        public List<Movie> GetMoviesByGenre(int id)
        {
            return _db.movies
                .Where(m => m.GenresId == id)
                .ToList();
        }


        public List<Movie> GetAllMoviesOrderedAscending()
        {
            return _db.movies
                .OrderBy(m => m.Name)
                .ToList();
        }

        public List<Movie> GetMoviesByUserDefinedGenre(string name)
        {
            return _db.movies
                .Where(m => m.Genres.GenreName == name)
                .ToList();
        }
    }
}

