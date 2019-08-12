using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using Notes.Models;
using System.Reflection;

namespace Notes.Data
{
    public class NotesDatabase
    {
        readonly SQLiteAsyncConnection _database;

        public NotesDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Note>().Wait();
            _database.CreateTableAsync<Reminder>().Wait();
        }

        public Task<List<Note>> GetItemsAsync()
        {
            return _database.Table<Note>().ToListAsync();
        }


        public Task<Note> GetByIdAsync(int id)
        {
            return _database.Table<Note>().Where(n => n.ID == id).FirstOrDefaultAsync();
        }

        public Task<List<Reminder>> GetRemaindersAsync()
        {
            return _database.Table<Reminder>().ToListAsync();
        }
        public Task<Reminder> GetRemainderAsync(int id)
        {
            return _database.Table<Reminder>().Where(n => n.ID == id).FirstOrDefaultAsync();
        }
        public Task<int> SaveItem(object item)
        {
            var currentItem = ChekType(item);
            if (currentItem !=0 )
            {
                return _database.UpdateAsync(item);
            }
            else
            {
                return _database.InsertAsync(item);
            }
        }

        public Task<int> DeleteAsync(object item)
        {
            return _database.DeleteAsync(item);
        }

        public int ChekType(object item)
        {
            Reminder r = new Reminder();
            Note n = new Note();

            var currentItem = item.GetType();
            int id = (int)currentItem.GetProperty("ID").GetValue(item, null);

            if (currentItem == typeof(Note))
            {
                return n.ID = id ;
            }
            if (currentItem == typeof(Reminder))
            {
                return r.ID = id;
            }
            return 0;
        }
    }
}
