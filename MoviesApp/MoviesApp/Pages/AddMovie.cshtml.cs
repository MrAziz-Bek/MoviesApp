using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MoviesApp.Data.Models;
using MoviesApp.Data.Services;

namespace MoviesApp.Pages;

public class AddMovieModel : PageModel
{
    [BindProperty]
    public Movie Movie { get; set; }

    private readonly IMoviesService _service;

    public AddMovieModel(IMoviesService service)
    {
        _service = service;
    }

    public void OnGet() { }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
            return Page();

        _service.Add(Movie);

        return Redirect("Movies");
    }
}