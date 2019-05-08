using System;
using System.Collections.Generic;
using System.Linq;
using SQLite;
using Xamarin.Forms;

namespace Week2
{
    public class DataBaseManager
    {
        private readonly SQLiteConnection _c;
        
        private DataBaseManager()
        {
            _c = DependencyService.Get<IDBInterface>().CreateConnection();
            _c.CreateTable<Movie>();
        }

        public List<Movie> GetAllMovies()
        {
            return (from m in _c.Table<Movie>() select m).ToList();
        }

        public void AddOrUpdateMovie(string title, string description, string imagesource)
        {
            var movie = new Movie
            {
                Description = description,
                ImageSource = imagesource,
                Title = title
            };

            _c.Insert(movie);
        }

        public void DeleteMovie(string title)
        {
            _c.Delete<Movie>(title);
        }

        public bool DoesMovieExist(string title)
        {
            bool Equal(string t) => t == title;
            return (from m in _c.Table<Movie>() select m.Title).Any(Equal);
        }

        public int GetMovieID(string title)
        {
            bool Equal(Movie m) => m.Title == title;
            return _c.Table<Movie>().Where(Equal).FirstOrDefault().MovieID;
        }
    }
}