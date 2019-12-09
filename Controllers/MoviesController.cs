using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vicky.Models;
using Vicky.ViewModels;

namespace Vicky.Controllers
{

    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;
        // GET: Movies
        public MoviesController()
        {
            _context = new ApplicationDbContext();

        }

        public ActionResult Index()
        {
            var movies = _context.Movies.Include(m => m.Genre).ToList();
            var viewModel = new MoviesViewModel()
            {
                Movies = movies,
            };
            return View(viewModel);
        }

        public ActionResult Detail(int id)
        {
            var movie = _context.Movies.Include(m => m.Genre).Include(m => m.Category).SingleOrDefault(m => m.Id == id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(movie);
            }
        }


        public ActionResult MovieForm()
        {
            var categories = _context.Categories;
            var genres = _context.Genres;

            var viewModel = new MovieFormViewModel()
            {
                Genres = genres,
                Categories = categories

            };

            return View(viewModel);
        }
        public ActionResult Random()
        {
            return View();
        }


        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
            base.Dispose(disposing);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {
            if (ModelState.IsValid)
            {
                if (movie.Id == null)
                {
                    _context.Movies.Add(movie);
                }
                else
                {
                    var movieInDb = _context.Movies.Single(c => c.Id == movie.Id);
                    movieInDb.Name = movie.Name;
                    movieInDb.ReleasedDate = movie.ReleasedDate;
                    movieInDb.GenreId = movie.GenreId;
                    movieInDb.CategoryId = movie.CategoryId;
                    movieInDb.Description = movie.Description;
                    movieInDb.Tags = movie.Tags;
                }

                _context.SaveChanges();
                return RedirectToAction("Index", "Movies");
            }

            var viewModel = new MovieFormViewModel()
            {
                Movie = movie,
                Genres = _context.Genres.ToList(),
                Categories = _context.Categories.ToList()
            };

            return View("MovieForm",viewModel);
        }

        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.Include(m => m.Genre).Include(m => m.Category).SingleOrDefault(m => m.Id == id);

            if (movie == null)
            {
                return HttpNotFound();
            }
            else
            {
                var viewModel = new MovieFormViewModel()
                {
                    Movie = movie,
                    Categories = _context.Categories.ToList(),
                    Genres = _context.Genres.ToList()
                };

                return View("MovieForm", viewModel);
            }
        }
    }

   

}
