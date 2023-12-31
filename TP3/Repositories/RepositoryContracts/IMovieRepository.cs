﻿// MovieRepository.cs
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using TP3.Models;

namespace TP4.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private readonly AppDbContext _db;

        public MovieRepository(AppDbContext db)
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
                var imagePath = Path.Combine("wwwroot/images", movie.ImageFile.FileName);
                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    movie.ImageFile.CopyTo(stream);
                }

                movie.Photo = $"/images/{movie.ImageFile.FileName}";
            }

            _db.movies.Add(movie);
            _db.SaveChanges();
        }

        public void EditMovie(Movie movie)
        {
            _db.Entry(movie).State = EntityState.Modified;
            _db.SaveChanges();
        }

        public void DeleteMovie(int id)
        {
            var movie = _db.movies.Find(id);

            if (movie != null)
            {
                _db.movies.Remove(movie);
                _db.SaveChanges();
            }
        }

        public List<Movie> GetMoviesByGenre(int genreId)
        {
            return _db.movies
                .Where(m => m.GenresId == genreId)
                .ToList();
        }

        public List<Movie> GetAllMoviesOrderedAscending()
        {
            return _db.movies
                .OrderBy(m => m.Name)
                .ToList();
        }

        public List<Movie> GetMoviesByUserDefinedGenre(string userDefinedGenre)
        {
            return _db.movies
                .Where(m => m.Genres.GenreName == userDefinedGenre)
                .ToList();
        }
    }
}
