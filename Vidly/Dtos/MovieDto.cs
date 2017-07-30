using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Dtos
{
  public class MovieDto
  {
    public int Id { get; set; }

    [Required(ErrorMessage = "Please enter movie's name")]
    [StringLength(255)]
    public string Name { get; set; }

    public GenreDto Genre { get; set; }

    [Required(ErrorMessage = "Please enter movie's genre")]
    public byte GenreId { get; set; }

    [Required(ErrorMessage = "Please enter movie's release date")]
    public DateTime ReleaseDate { get; set; }
    
    public DateTime DateAdded { get; set; }

    [Required(ErrorMessage = "Please enter movie's number in stock")]
    public int NumberInStock { get; set; }
  }
}