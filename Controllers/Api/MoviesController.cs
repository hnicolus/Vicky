using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using AutoMapper;
using Vicky.Dtos;
using Vicky.Models;

namespace Vicky.Controllers.Api
{
    public class MoviesController : ApiController
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();

        }


        [HttpGet]
        public IEnumerable<MovieDto> GetMovies()
        {
            return  _context.Movies.ToList().Select(Mapper.Map<Movie,MovieDto>);
        }


        [HttpGet]
        public MovieDto Movie(int id)
        {
            var movie =  _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movie == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            return Mapper.Map<Movie,MovieDto>(movie);
        }



        [HttpPost]
        public IHttpActionResult CreateMovie(MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
        
            var movie = Mapper.Map<MovieDto, Movie>(movieDto);
            _context.Movies.Add(movie);
            _context.SaveChanges();

            movieDto.Id = movie.Id;

            return Created(new Uri(Request.RequestUri + "/"+ movie.Id),movieDto);
        }

        // PUT /api/movies/id
        [HttpPut]
        public void UpdateMovie(int id, MovieDto movieDto)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            else
            {
                var movieInDb = _context.Movies.SingleOrDefault(m => m.Id == id);
                if (movieInDb != null)
                {
                    Mapper.Map(movieDto,movieInDb);
                    //movieInDb.Name = movieDto.Name;
                    //movieInDb.ReleasedDate = movieDto.ReleasedDate;
                    //movieInDb.CategoryId = movieDto.CategoryId;
                    //movieInDb.GenreId = movieDto.GenreId;
                    //movieInDb.Description = movieDto.Description;
                    //movieInDb.Tags = movieDto.Tags;
                    //movieInDb.Views = movieDto.Views;

                    _context.SaveChanges();

                }
                else
                {
                    throw new HttpResponseException(HttpStatusCode.NotFound);
                }
            }
        }
        // DELETE /api/movieDto/id
        [HttpDelete]
        public void DeleteMovie(int id)
        {
            var movieInDb = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movieInDb != null)
            {
                _context.Movies.Remove(movieInDb);
                _context.SaveChanges();
            }
            else
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

        }
    }
}
