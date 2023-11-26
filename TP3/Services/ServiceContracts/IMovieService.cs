using TP3.Models;

namespace TP4.Services.ServiceContracts
{
    public interface IMovieService
    {
        List<Movie> GetAllMovies();
        Movie GetMovieById(int id);
        void CreateMovie(Movie movie);
        void Edit(Movie movie);
        void Delete(int id);

        /*used linq queries in those below*/
        List<Movie> GetMoviesByGenre(int genreId);
        List<Movie> GetAllMoviesOrderedAscending();
        List<Movie> GetMoviesByUserDefinedGenre(string userDefinedGenre);
    }

}
