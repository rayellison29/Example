using ForDemoApplication.Models;
using ForDemoApplication.Views.Home;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using static Views.Home;

namespace ForDemoApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ForDemoApplicationDBContext _context;
        public HomeController(ILogger<HomeController> logger, ForDemoApplicationDBContext context)
        {
            _logger = logger;
            _context = context;
        }

       
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Movies()
        {
            var myMovies = _context.Movies.ToList();

            ViewBag.Movies = myMovies;

            return View(myMovies);
        }
       /* public IActionResult ViewMovies()
        {
            var myMovies = _context.Movies.ToList();

            ViewBag.Movies = myMovies;

            return View(myMovies);
        }
       */
        public IActionResult CreateEditMovie(int? Id)
        {
            if (Id != null)
            {
                var valinDB = _context.Movies.SingleOrDefault(x => x.Id == Id);

                return View(valinDB);
            }
            return View();
        }
        public IActionResult ViewMoviesForm(Movie model)
        {
            if (model.Id == 0)
            {
                _context.Movies.Add(model);
            }
            else
            {
                _context.Movies.Update(model);
            }

            _context.SaveChanges();

            return RedirectToAction("Movies");
        }
        public IActionResult DeleteMovie(int id)
        {
            var valinDB = _context.Movies.SingleOrDefault(x => x.Id == id);
            _context.Movies.Remove(valinDB);
            _context.SaveChanges();

            return RedirectToAction("Movies");
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
