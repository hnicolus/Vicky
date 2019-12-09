using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vicky.Models;

namespace Vicky.ViewModels
{
    public class MoviesViewModel
    {
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<Genre> Genres { get; set; }
        public List<Movie> Movies { get; set; }
    }
}