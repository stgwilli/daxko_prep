using System;
using System.Collections.Generic;
using nothinbutdotnetprep.specs.utility;

namespace nothinbutdotnetprep.collections
{
    public class MovieLibrary
    {
        IList<Movie> movies;

        public MovieLibrary(IList<Movie> list_of_movies)
        {
            movies = list_of_movies;
        }

        public IEnumerable<Movie> all_movies()
        {
            foreach (var movie in movies)
                yield return movie;
        }

        public void add(Movie movie)
        {
            if (does_not_contains(movie))
                movies.Add(movie);
        }

        bool does_not_contains(Movie movie)
        {
            return !contains(movie);
        }

        bool contains(Movie movie)
        {
            if (movies.Contains(movie))
                return true;

            foreach (var movie1 in movies)
            {
                if (movie1.title == movie.title)
                    return true;
            }

            return false;
        }

        public IEnumerable<Movie> sort_all_movies_by_title_descending()
        {
            var sorted_movies = new SortedList<string, Movie>(new ReverseComparer<string>());
            foreach (var movie in movies)
                sorted_movies.Add(movie.title, movie);

            foreach (var sorted_movie in sorted_movies)
                yield return sorted_movie.Value;
        }

        public IEnumerable<Movie> sort_all_movies_by_title_ascending()
        {
            var sorted_movies = new SortedList<string, Movie>();
            foreach (var movie in movies)
                sorted_movies.Add(movie.title, movie);

            foreach (var sorted_movie in sorted_movies)
                yield return sorted_movie.Value;
        }

        public IEnumerable<Movie> sort_all_movies_by_movie_studio_and_year_published()
        {
            var sorted_by_production_studio = new SortedList<Tuple<ProductionStudio, DateTime>, Movie>(new ProductionStudioAndDateTimeComparer());
            foreach (var movie in movies)
                sorted_by_production_studio.Add(new Tuple<ProductionStudio, DateTime>(movie.production_studio, movie.date_published), movie);

            foreach (var movie in sorted_by_production_studio)
                yield return movie.Value;
        }

        public IEnumerable<Movie> sort_all_movies_by_date_published_descending()
        {
            var sorted_movies = new SortedList<DateTime, Movie>(new ReverseComparer<DateTime>());
            foreach (var movie in movies)
                sorted_movies.Add(movie.date_published, movie);
            
            foreach (var sorted_movie in sorted_movies)
                yield return sorted_movie.Value;
        }

        public IEnumerable<Movie> sort_all_movies_by_date_published_ascending()
        {
            var sorted_movies = new SortedList<DateTime, Movie>();
            foreach (var movie in movies)
                sorted_movies.Add(movie.date_published, movie);

            foreach (var sorted_movie in sorted_movies)
                yield return sorted_movie.Value;
        }
    }
}