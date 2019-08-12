using SQLite;

namespace Notes.Models
{
    public class Base
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
    }
}
