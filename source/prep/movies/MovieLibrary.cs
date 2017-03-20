using System;
using System.Collections.Generic;

namespace code.prep.movies
{
	public class MovieLibrary
	{
		readonly IList<Movie> movies;

		public MovieLibrary(IList<Movie> list_of_movies)
		{
			movies = list_of_movies;
		}

		public IEnumerable<Movie> all_movies()
		{
			return movies;
		}

		public void add(Movie movie)
		{
			movies.Add(movie);
		}

		private IEnumerable<Movie> search_movies(Predicate<Movie> moviePredicate)
		{
			foreach (var movie in movies)
			{
				if (moviePredicate(movie))
					yield return movie;
			}
		}

		public IEnumerable<Movie> all_movies_published_by_pixar()
		{
			return movies_from_studio(ProductionStudio.Pixar);
		}

		public IEnumerable<Movie> movies_from_studio(ProductionStudio studio)
		{
			return search_movies(m => m.production_studio == studio);
		}

		public IEnumerable<Movie> all_movies_published_by_pixar_or_disney()
		{
			return search_movies(m => m.production_studio == ProductionStudio.Pixar || m.production_studio == ProductionStudio.Disney);
		}

		public IEnumerable<Movie> all_movies_not_published_by_pixar()
		{
			return search_movies(m => m.production_studio != ProductionStudio.Pixar);
		}

		public IEnumerable<Movie> all_movies_published_after(int year)
		{
			return search_movies(m => m.date_published.Year > year);
		}

		public IEnumerable<Movie> all_movies_published_between_years(int startingYear, int endingYear)
		{
			return search_movies(m => m.date_published.Year >= startingYear && m.date_published.Year <= endingYear);
		}

		private IEnumerable<Movie> movie_of_type(Genre genre)
		{
			return search_movies(m => m.genre == genre);
		}

		public IEnumerable<Movie> all_kid_movies()
		{
			return movie_of_type(Genre.kids);
		}

		public IEnumerable<Movie> all_action_movies()
		{
			return movie_of_type(Genre.action);
		}

		public IEnumerable<Movie> sort_all_movies_by_title_descending()
		{
			throw new NotImplementedException();
		}

		public IEnumerable<Movie> sort_all_movies_by_title_ascending()
		{
			throw new NotImplementedException();
		}

		public IEnumerable<Movie> sort_all_movies_by_movie_studio_and_year_published()
		{
			throw new NotImplementedException();
		}

		public IEnumerable<Movie> sort_all_movies_by_date_published_descending()
		{
			throw new NotImplementedException();
		}

		public IEnumerable<Movie> sort_all_movies_by_date_published_ascending()
		{
			throw new NotImplementedException();
		}
	}
}
