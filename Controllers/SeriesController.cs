using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vicky.Models;
using System.Data.Entity;
using Vicky.ViewModels.Series;

namespace Vicky.Controllers
{
    public class SeriesController : Controller
    {
        private ApplicationDbContext _context;
        public SeriesController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: Series
        public ActionResult Index()
        {
            var listOfSeries = _context.Series.Include(m => m.Seasons).ToList();
            var genres = _context.Genres.ToList();
            var categories = _context.Categories.ToList();
            var viewModel = new SeriesIndexViewModel()
            {
                Categories = categories,
                Genres = genres,
                Series = listOfSeries

            };

            return View(viewModel);
        }

        public ActionResult Form()
        {
            var listOfSeries = _context.Series.Include(m => m.Seasons).ToList();
            var genres = _context.Genres.ToList();
            var categories = _context.Categories.ToList();
            var viewModel = new SeriesFormViewModel()
            {
                Genres = genres,
                Categories = categories,

            };
            return View(viewModel);
        }

        public ActionResult Detail(int id)
        {
            var series = _context.Series.Single(s => s.Id == id);
            if (series == null)
                return HttpNotFound();
            return View(series);
        }
    }
}