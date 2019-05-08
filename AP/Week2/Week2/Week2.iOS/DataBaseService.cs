using System.IO;
using Foundation;
using SQLite;
using Week2.Droid;
using Xamarin.Forms;
using Environment = System.Environment;

[assembly: Dependency(typeof(DataBaseService))]
namespace Week2.Droid
{
    public class DataBaseService : IDBInterface
    {
        public SQLiteConnection CreateConnection()
        {
            const string sqliteFilename = "MovieDB.db";
            var docFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var libFolder = Path.Combine(docFolder, "..", "Library", "Databases");

            if (!Directory.Exists(libFolder)) Directory.CreateDirectory(libFolder);
            var path = Path.Combine(libFolder, sqliteFilename);
            if (!File.Exists(path))
            {
                var ExistingDb = NSBundle.MainBundle.PathForResource("MovieDatabase", "db");
                File.Copy(ExistingDb, path);
            }

            var conn = new SQLiteConnection(path, false);
            return conn;
        }
    }
}