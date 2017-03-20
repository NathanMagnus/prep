using code.utility.matching;

namespace code.prep.movies
{
  public class IsPublishedAfter : IMatchA<Movie>
  {
    int year;

    public IsPublishedAfter(int year)
    {
      this.year = year;
    }

    public bool matches(Movie item)
    {
      return item.date_published.Year > year;
    }
  }
}