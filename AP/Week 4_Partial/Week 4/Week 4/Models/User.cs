using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Week_4.Models
{
    public class User
    {
        [PrimaryKey,AutoIncrement,Unique,NotNull]
        public int UserID {get; set; }

        [Unique,NotNull]
        public string Username {get; set; }

        [NotNull]
        public string Password {get; set; }
    }
}
