using System;
using SQLite;

namespace Notes.Models
{
    public class Note : Base
    {
        public string Text { get; set; }
        public DateTime Date { get; set; }
    }
}
