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
        
        public DataBaseManager()
        {
            _c = DependencyService.Get<IDBInterface>().CreateConnection();
            _c.CreateTable<Movie>();
        }

        public List<Movie> GetAllMovies()
        {
            return (from m in _c.Table<Movie>() select m).ToList();
        }

        public void AddOrUpdateMovie(Movie m)
        {
            if(!DoesMovieExist(m.Title))
                _c.Insert(m);
        }

        public void DeleteMovie(string title)
        {
            _c.Delete<Movie>(GetMovieID(title));
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