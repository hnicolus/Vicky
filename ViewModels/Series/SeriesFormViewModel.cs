using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vicky.Models;

namespace Vicky.ViewModels.Series
{
    public class SeriesFormViewModel
    {
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<Genre> Genres { get; set; }
        public Models.Series Series { get; set; }
    }
}