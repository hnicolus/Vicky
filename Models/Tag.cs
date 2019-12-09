using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vicky.Models
{
    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Movie> Movies { get; set; }
        public List<Series> Series { get; set; }
    }
}