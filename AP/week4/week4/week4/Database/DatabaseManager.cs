using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using week4.Models;
using Xamarin.Forms;

namespace week4.Database
{
    class DatabaseManager
    {
        SQLiteConnection dbConnection;

        /// <summary>
        /// Constructor 
        /// </summary>
        public DatabaseManager()
        {
            dbConnection = DependencyService.Get<IDBInterface>().CreateConnection();
        }
        /// <summary>
        /// Gets all movies for Listview
        /// </summary>
        public List<Movie> GetAllMovies()
        {
            return new List<Movie>(dbConnection.Query<Movie>("SELECT * FROM [Movie]"));
        }
        /// <summary>
        /// Gets all movies for Listview by user
        /// </summary>
        public List<Movie> GetAllMoviesByUser(string username)
        {
            int userID = dbConnection.FindWithQuery<int>("SELECT UserID FROM [User] WHERE Username = @0", username);
            return new List<Movie>(dbConnection.Query<Movie>("SELECT * FROM MOVIE, MOVIEUSER WHERE MOVIE.MOVIEID = MOVIEUSER.MOVIEID AND MOVIEUSER.USERID = @0", userID));
        }
        /// <summary>
        /// Gets all series for Listview
        /// </summary>
        public List<Series> GetAllSeries()
        {
            return new List<Series>(dbConnection.Query<Series>("SELECT * FROM [Series]"));
        }
        /// <summary>
        /// Gets all series for Listview by user
        /// </summary>
        public List<Series> GetAllSeriesByUser(string username)
        {
            int userID = dbConnection.FindWithQuery<int>("SELECT UserID FROM [User] WHERE Username = @0", username);
            return new List<Series>(dbConnection.Query<Series>("SELECT * FROM SERIES, SERIESUSER WHERE SERIES.SERIESID = SERIESUSER.SERIESID AND SERIESUSER.USERID = @0", userID));
        }
        /// <summary>
        ///  Gets account or else returns null
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        public User GetUser(string username, string password)
        {
            return dbConnection.FindWithQuery<User>("SELECT * FROM [User] WHERE Username = @0 AND Password = @1", username, password);
        }
        /// <summary>
        /// Checks if account exists
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        public bool doesAccountExist(string username, string password)
        {
            return GetUser(username, password) != null;
        }
        /// <summary>
        /// Adds user to db if account does not exsist
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        public bool AddUser(string username, string password)
        {
            if (!doesAccountExist(username, password))
            {
                dbConnection.Insert(new User { Username = username, Password = password });
                return true;
            }
            else
                return false;
        }
        /// <summary>
        /// Gets movie from db
        /// </summary>
        /// <param name="title"></param>
        /// <param name="description"></param>
        /// <returns></returns>
        public Movie GetMovie(string title, string description)
        {
            return dbConnection.FindWithQuery<Movie>("SELECT * FROM [Movie] WHERE Title = @0 AND Description = @1", title, description); 
        }
        /// <summary>
        /// Gets series from db
        /// </summary>
        /// <param name="title"></param>
        /// <param name="description"></param>
        /// <returns></returns>
        public Series GetSeries(string title, string description)
        {
            return dbConnection.FindWithQuery<Series>("SELECT * FROM [Series] WHERE Title = @0 AND Description = @1", title, description);
        }
        /// <summary>
        /// Adds movie if not exsists or updates if does exsist 
        /// </summary>
        /// <param name="title"></param>
        /// <param name="description"></param>
        /// <param name="year"></param>
        public void AddOrUpdateMovie(string title,string description,string year)
        {
            if (GetMovie(title, description) != null)
                dbConnection.Insert(new Movie { Title = title, Description = description, Year = year });
            else
                dbConnection.Update(new Movie { Title = title, Description = description, Year = year }); 
        }
        /// <summary>
        /// Adds series if not exsists or updates if does exsists
        /// </summary>
        /// <param name="title"></param>
        /// <param name="description"></param>
        /// <param name="yearStarted"></param>
        /// <param name="yearEnded"></param>
        /// <param name="numberOfEpisodes"></param>
        /// <param name="numberOfSeasons"></param>
        public void AddSeries(string title, string description, int yearStarted, int yearEnded,int numberOfEpisodes, int numberOfSeasons)
        {
            if (GetMovie(title, description) != null)
                dbConnection.Insert(new Series { Title = title, Description = description, YearStarted = yearStarted, YearEnded = yearEnded, NumberOfEpisodes = numberOfEpisodes, NumberOfSeasons = numberOfSeasons});
            else
                dbConnection.Update(new Series { Title = title, Description = description, YearStarted = yearStarted, YearEnded = yearEnded, NumberOfEpisodes = numberOfEpisodes, NumberOfSeasons = numberOfSeasons });
        }
    }
}
