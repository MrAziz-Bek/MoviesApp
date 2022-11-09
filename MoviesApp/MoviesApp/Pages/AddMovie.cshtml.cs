using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MoviesApp.Data;
using MoviesApp.Data.Models;

namespace MoviesApp.Pages;

public class AddMovieModel : PageModel
{
    [BindProperty]
    public Movie Movie { get; set; }

    private readonly AppDbContext _context;

    public AddMovieModel(AppDbContext context)
    {
        _context = context;
    }

    public void OnGet() { }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
            return Page();

        _context.Movies.Add(Movie);
        _context.SaveChanges();

        return Redirect("Movies");
    }
}