using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using Vicky.Models;

namespace Vicky.EntityConfigurations
{
    public class SeriesConfigurations : EntityTypeConfiguration<Series>
    {

        public SeriesConfigurations()
        {
            Property(t => t.Name)
                .HasMaxLength(255).IsRequired();

            Property(t => t.Description).IsRequired();

            HasRequired(c => c.Category)
                .WithMany(t => t.Series)
                .HasForeignKey(m => m.CategoryId);

            HasRequired(c => c.Genre)
                .WithMany(t => t.Series)
                .HasForeignKey(m => m.GenreId);


            HasMany(s => s.Seasons)
                .WithRequired(s => s.Series);
            HasMany(t => t.Tags).WithMany(t => t.Series)
                .Map(m => m.ToTable("SeriesTags"));

        }
    }
}


    