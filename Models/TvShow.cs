using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vicky.Models
{
    public class TvShow
    {
        public TvShow()
        {
            PublishedDate = DateTime.Now;
        }
        public int? Id { get; set; }
        [Required]
        [MaxLength(255)]
        public string  Name { get; set; }
        [Required]
        public string Description { get; set; }
    
        public int GenreId { get; set; }
        public Genre Genre { get; set; }

        public List<Tag> Tags { get; set; }
        public DateTime PublishedDate { get; set; }
        public DateTime ReleasedDate { get; set; }
        public int? Views { get; set; }
    }
}