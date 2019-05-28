using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Week_4.Models
{
    class Movie
    {
        [PrimaryKey,AutoIncrement,Unique,NotNull]
        public int MovieID {get; set; }

        [Unique,NotNull]
        public string Title {get; set; }

        [NotNull]
        public string Year {get; set; }
        
        public string Description {get; set; }
    }
}
