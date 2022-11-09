using Microsoft.AspNetCore.Mvc.RazorPages;
using MoviesApp.Data;
using MoviesApp.Data.Models;

namespace MoviesApp.Pages;

public class MovieModel : PageModel
{
    public Movie? Movie { get; set; }

    private readonly AppDbContext _context;

    public MovieModel(AppDbContext context)
    {
        _context = context;
    }

    public void OnGet(int id)
    {
        Movie = _context.Movies.FirstOrDefault(m => m.Id == id);

        
    }
}