using System;

namespace code.prep.movies
{
  public class Movie : IEquatable<Movie>
  {
    public string title { get; set; }
    public ProductionStudio production_studio { get; set; }
    public Genre genre { get; set; }
    public int rating { get; set; }
    public DateTime date_published { get; set; }

	  public bool Equals(Movie other)
	  {
		  if (ReferenceEquals(null, other)) return false;
		  if (ReferenceEquals(this, other)) return true;
		  return string.Equals(title, other.title);
	  }

	  public override bool Equals(object obj)
	  {
		  return Equals(obj as Movie);
	  }

	  public override int GetHashCode()
	  {
		  unchecked
		  {
			  var hashCode = (title != null ? title.GetHashCode() : 0);
			  hashCode = (hashCode * 397) ^ (production_studio != null ? production_studio.GetHashCode() : 0);
			  hashCode = (hashCode * 397) ^ (genre != null ? genre.GetHashCode() : 0);
			  hashCode = (hashCode * 397) ^ rating;
			  hashCode = (hashCode * 397) ^ date_published.GetHashCode();
			  return hashCode;
		  }
	  }
  }
}
