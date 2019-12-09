using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity.ModelConfiguration;
using System.Web;
using Vicky.Models;

namespace Vicky.EntityConfigurations
{
    public class MovieConfiguration : EntityTypeConfiguration<Movie>
    {
        public MovieConfiguration()
        {



            Property(t => t.Description)
                .IsRequired();

            HasMany(c => c.Tags)
            .WithMany(t => t.Movies)
            .Map(m => m.ToTable("MovieTags"));

            HasRequired(c => c.Category)
                .WithMany(t => t.Movies)
                .HasForeignKey(M => M.CategoryId);

            HasRequired(c => c.Genre)
                .WithMany(t => t.Movies)
                .HasForeignKey(m => m.GenreId);
        }
    }
}