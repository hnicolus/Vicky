using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vicky.Models;

namespace Vicky.Dtos
{
    public class MovieDto
    {
        public int? Id { get; set; }
        [Required]
        [MaxLength(255)]
        public int CategoryId { get; set; }

        public string Name { get; set; }
        [Required]
        public string Description { get; set; }

        public int GenreId { get; set; }

        public List<Tag> Tags { get; set; }
        public DateTime PublishedDate { get; set; }
        public DateTime ReleasedDate { get; set; }
        public int? Views { get; set; }
    }
}