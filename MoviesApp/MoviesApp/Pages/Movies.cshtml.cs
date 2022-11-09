using Microsoft.AspNetCore.Mvc.RazorPages;
using MoviesApp.Data.Models;
using MoviesApp.Data.Services;

namespace MoviesApp.Pages;

public class MoviesModel : PageModel
{
    private readonly IMoviesService _service;

    public List<Movie> Movies { get; set; }

    public MoviesModel(IMoviesService service)
    {
        _service = service;
    }

    public void OnGet()
    {
        Movies = _service.GetAll();
    }
}