using System.Runtime.InteropServices;
using SQLite;

namespace Week2
{
    public class Movie
    {
        [PrimaryKey,AutoIncrement,Unique,NotNull]
        public int MovieID { get; set; }
        [Unique,NotNull]
        public string Title { get; set; }
        [NotNull]
        public string Description { get; set; }
        [NotNull]
        public string ImageSource { get; set; }
    }
}