using System;
using SQLite;

namespace Notes.Models
{
    public class Note : Base
    {
        [PrimaryKey, AutoIncrement]
        
        public string Text { get; set; }
        public DateTime Date { get; set; }
    }
}
