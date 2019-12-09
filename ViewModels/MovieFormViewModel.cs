using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vicky.Models;

namespace Vicky.ViewModels
{
    public class MovieFormViewModel
    {
        public IEnumerable<Genre> Genres { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public Movie Movie { get; set; }

        public string Title { get; set; }


       public void SetTitle()
        {
            if (Movie == null)
            {
                Title = "New Movie";
            }
            else
            {
                Title = "Edit Movie";
            }
        }
    }
}