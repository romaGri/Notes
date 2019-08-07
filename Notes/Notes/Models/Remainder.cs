using SQLite;
using System;


namespace Notes.Models
{
    public class Remainder
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public DateTime GetDate { get; set; }
        public DateTime GetTime { get; set; }
        public string Text { get; set; }
    }
}
