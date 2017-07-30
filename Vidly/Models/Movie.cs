using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
  public class Movie
  {
    public int Id { get; set; }

    [Required(ErrorMessage = "Please enter movie's name")]
    [StringLength(255)]
    [Display(Name = "Name")]
    public string Name { get; set; }
        
    public Genre Genre { get; set; }
    [Required(ErrorMessage = "Please enter movie's genre")]
    [Display(Name = "Genre")]
    public byte GenreId { get; set; }

    [Required(ErrorMessage = "Please enter movie's release date")]
    [Display(Name = "Release date")]
    public DateTime ReleaseDate { get; set; }

    [Display(Name = "Date added")]
    public DateTime DateAdded { get; set; }

    [Required(ErrorMessage = "Please enter movie's number in stock")]
    [Display(Name = "Remaining")]
    public int NumberInStock { get; set; }

    public byte NumberAvailable { get; set; }
  }
}