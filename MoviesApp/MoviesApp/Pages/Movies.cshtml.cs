using Microsoft.AspNetCore.Mvc.RazorPages;
using MoviesApp.Data;
using MoviesApp.Data.Models;

namespace MoviesApp.Pages;

public class MoviesModel : PageModel
{
    private readonly AppDbContext _context;

    public List<Movie> Movies { get; set; }

    public MoviesModel(AppDbContext context)
    {
        _context = context;
    }

    public void OnGet()
    {
        Movies = _context.Movies.ToList();
    }
}