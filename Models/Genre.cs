using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vicky.Models
{
    public class Genre
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(200)]
        public string Name { get; set; }

        public List<Movie> Movies { get; set; }
        public List<Series> Series { get; set; }

    }
}