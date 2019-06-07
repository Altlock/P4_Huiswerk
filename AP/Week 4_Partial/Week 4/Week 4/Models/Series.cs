using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Week_4.Models
{
    class Series
    {
        [PrimaryKey,AutoIncrement,Unique,NotNull]
        public int SeriesID {get; set; }
        [Unique,NotNull]
        public string Title {get; set; }
        [NotNull]
        public string YearStarted {get; set; }
        
        public string YearEnded {get; set; }

        public string Description {get; set; }
        [NotNull]
        public string NumberOfEpisodes {get; set; }
        [NotNull]
        public string NumberOfSeasons {get; set; }
    }
}
