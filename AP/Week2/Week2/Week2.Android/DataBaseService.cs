using System.IO;
using Android.OS;
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
            var documentsDirectoryPath = System.Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentsDirectoryPath, sqliteFilename);

            if (!File.Exists(path))
            {
                using (var binaryReader = new BinaryReader
                    (Android.App.Application.Context.Assets.Open(sqliteFilename)))
                {
                    using (var binaryWriter = new BinaryWriter
                        (new FileStream(path, FileMode.Create)))
                    {
                        var buffer = new byte[2048];
                        var length = 0;
                        while ((length = binaryReader.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            binaryWriter.Write(buffer, 0, length);
                        }
                    }
                }
            }
            var conn = new SQLiteConnection(path, false);

            return conn;
        }
    }
}