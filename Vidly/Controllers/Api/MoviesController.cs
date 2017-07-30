using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Models;
using Vidly.Dtos;
using AutoMapper;

namespace Vidly.Controllers.Api
{
    public class MoviesController : ApiController
    {
      ApplicationDbContext _context;

      public MoviesController()
      {
        _context = new ApplicationDbContext();
      }

      protected override void Dispose(bool disposing)
      {
        _context.Dispose();
      }

      // GET /api/movies
      public IHttpActionResult GetMovies(string query = null)
      {
        var moviesQuery = _context.Movies
        .Include(c => c.Genre)
        .Where(m => m.NumberAvailable > 0);

        if (!String.IsNullOrWhiteSpace(query))
          moviesQuery = moviesQuery.Where(c => c.Name.Contains(query));

        var movieDtos = moviesQuery
          .ToList()
          .Select(Mapper.Map<Movie, MovieDto>);

        return Ok(movieDtos);
      }

      // GET /api/movies/{id}
      public MovieDto GetMovie(int id)
      {
        var movie = _context.Movies.Single(m => m.Id == id);

        if (movie == null)
          throw new HttpResponseException(HttpStatusCode.NotFound);

        return Mapper.Map<Movie, MovieDto>(movie);
      }

      // POST /api/movies
      [HttpPost]
      public MovieDto CreateMovie(MovieDto movieDto)
      {
        if (!ModelState.IsValid)
          throw new HttpResponseException(HttpStatusCode.BadRequest);

        var movie = Mapper.Map<MovieDto, Movie>(movieDto);
        _context.Movies.Add(movie);
        _context.SaveChanges();

        movieDto.Id = movie.Id;

        return movieDto;
      }

      // PUT /api/movies/id
      [HttpPut]
      public void UpdateMovie(int id, MovieDto movieDto)
      {
        if (!ModelState.IsValid)
          throw new HttpResponseException(HttpStatusCode.BadRequest);

        var movieInDb = _context.Movies.SingleOrDefault(m => m.Id == id);

        if (movieInDb == null)
          throw new HttpResponseException(HttpStatusCode.NotFound);

        Mapper.Map(movieDto, movieInDb);

        _context.SaveChanges();
      }

      // DELETE /api/movies/id
      [HttpDelete]
      public void DeleteMovie(int id)
      {
      var movie = _context.Movies.SingleOrDefault(m => m.Id == id);

      if (movie == null)
        throw new HttpResponseException(HttpStatusCode.NotFound);

      _context.Movies.Remove(movie);
      _context.SaveChanges();
      }
    }
}
