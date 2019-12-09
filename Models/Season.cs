using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vicky.Models
{
    public class Season : TvShow
    {
        public Series Series { get; set; }
        public List<Episode> Episodes { get; set; }
    }
}   