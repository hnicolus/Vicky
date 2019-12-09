using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vicky.Models
{
    public class Series : TvShow
    {
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public List<Season> Seasons { get; set; }

    }
}