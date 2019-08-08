using SQLite;
using System;


namespace Notes.Models
{
    public class Reminder : Base
    {
        [PrimaryKey, AutoIncrement]
        public DateTime GetDate { get; set; }
        public DateTime GetTime { get; set; }
        public string Text { get; set; }
    }
}
