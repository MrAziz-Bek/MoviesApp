using Microsoft.AspNetCore.Mvc.RazorPages;
using MoviesApp.Data.Models;
using MoviesApp.Data.Services;

namespace MoviesApp.Pages;

public class MovieModel : PageModel
{
    public Movie? Movie { get; set; }

    private readonly IMoviesService _service;

    public MovieModel(IMoviesService service)
    {
        _service = service;
    }

    public void OnGet(int id)
    {
        Movie = _service.Get(id);        
    }
}