﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
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

        public ActionResult Index()
        {
          if (User.IsInRole(RoleName.CanManageMovies))
            return View("List");

          return View("ReadOnlyList");
        }

    public ActionResult Edit(int id)
    {
      var movie = _context.Movies.SingleOrDefault(m => m.Id == id);

      if (movie == null)
        return HttpNotFound();

      var viewModel = new NewMovieViewModel
      {
        Movie = movie,
        Genres = _context.Genres.ToList()
      };

      return View("New", viewModel);
    }        

        public ActionResult Details(int id)
        {
          var movie = _context.Movies.Include(m => m.Genre).SingleOrDefault(c => c.Id == id);

          return View(movie);
        }

    [HttpPost]
    public ActionResult Create(Movie movie)
    {
      if (movie.Id == 0)
      {
        movie.DateAdded = DateTime.Now;
        _context.Movies.Add(movie);
      }
      else
      {
        var movieInDb = _context.Movies.Single(m => m.Id == movie.Id);
        movieInDb.Name = movie.Name;
        movieInDb.GenreId = movie.GenreId;
        movieInDb.NumberInStock = movie.NumberInStock;
        movieInDb.ReleaseDate = movie.ReleaseDate;
      }

      _context.SaveChanges();

      return RedirectToAction("Index", "Movies");
    }

    [Authorize(Roles = RoleName.CanManageMovies)]
    public ActionResult New()
    {
      var genres = _context.Genres.ToList();
      var viewModel = new NewMovieViewModel
      {
        Movie = new Movie(),
        Genres = genres
      };

      return View(viewModel);
    }

        //[Route("movies/released/{year}/{month:regex(\\d{4}):range(1, 12)}")]
        //public ActionResult ByReleaseDate(int month, int year)
        //{
        //    return View();
        //}
    }
}