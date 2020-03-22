using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VideoRental.Context;
using VideoRental.Dtos;
using VideoRental.Models;

namespace VideoRental.Controllers.Api
{
    public class MoviesController : ApiController
    {
        private readonly VideoRentalDbContext _context;

        public MoviesController()
        {
            _context = new VideoRentalDbContext();
        }

        public IHttpActionResult Get()
        {
            var movies =_context.Movies.ToList().Select(Mapper.Map<Movie, MovieDto>);

            if (movies == null)
                return BadRequest("No movies found");

            return Ok(movies);
        }
        
        public IHttpActionResult Get(int id)
        {
            var movie = _context.Movies.FirstOrDefault(x => x.MovieId == id);

            if (movie == null)
                return BadRequest("No movie found for matching criteria");

            return Ok(Mapper.Map<Movie, MovieDto>(movie));
        }

        [HttpPost]
        public IHttpActionResult PostMovie([FromBody]MovieDto movieDto)
        {
            var movie = Mapper.Map<MovieDto, Movie>(movieDto);
            _context.Movies.Add(movie);
            _context.SaveChanges();

            if (movie.MovieId == 0)
                return BadRequest("An error occurred while updating the movie");

            movieDto.MovieId = movie.MovieId;
            return Ok(movieDto);
        }

        [HttpPut]
        public IHttpActionResult PutMovie([FromBody] MovieDto movieDto)
        {
            var movieInDb = _context.Movies.AsNoTracking().FirstOrDefault(x => x.MovieId == movieDto.MovieId);

            if (movieInDb == null)
                return BadRequest("Movie not found");

            Mapper.Map(movieDto, movieInDb);

            return Ok("");
        }        
    }
}