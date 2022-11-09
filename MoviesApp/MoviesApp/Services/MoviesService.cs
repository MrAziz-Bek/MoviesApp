using MoviesApp.Data.Models;

namespace MoviesApp.Data.Services;

public class MoviesService : IMoviesService
{
    private readonly AppDbContext _context;

    public MoviesService(AppDbContext context)
    {
        _context = context;
    }
    
    public void Add(Movie movie)
    {
        _context.Movies.Add(movie);
        _context.SaveChanges();
    }

    public Movie? Get(int id)
        => _context.Movies.FirstOrDefault(m => m.Id == id);

    public List<Movie> GetAll()
        => _context.Movies.ToList();
}