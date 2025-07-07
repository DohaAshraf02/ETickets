using AutoMapper;
using ETickets.Models;
using ETickets.Repositories;
using ETickets.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ETickets.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly MovieRepository _movieRepository;
        private readonly IMapper _mapper;

        public HomeController(ILogger<HomeController> logger,
            MovieRepository movieRepository,
            IMapper mapper)
        {
            _movieRepository = movieRepository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var movies = await _movieRepository.GetAllMoviesAsync();
            var moviesDtos = _mapper.Map<IEnumerable<MovieDto>>(movies);

            return View(moviesDtos);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
