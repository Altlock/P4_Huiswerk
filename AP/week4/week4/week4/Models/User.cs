using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace week4.Models
{
    class User
    {
        [PrimaryKey, AutoIncrement, Unique, NotNull]
        public int UserID { get; set; }
        [Unique, NotNull]
        public string Username { get; set; }
        [NotNull]
        public string Password { get; set; }
    }
}
