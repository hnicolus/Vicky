using System.Collections.Generic;
using Vicky.Models;
namespace Vicky.ViewModels.Series
{
    public class SeriesIndexViewModel
    {
        public List<Category> Categories { get; set; }
        public List<Genre> Genres { get; set; }
        public List<Models.Series> Series { get; set; }
    }
}