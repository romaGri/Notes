using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using Notes.Models;

namespace Notes.Data
{
    public class NotesDatabase
    {
        readonly SQLiteAsyncConnection _database;

        public NotesDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Note>().Wait();
        }

        public Task<List<Note>> GetNotesAsync()
        {
            return _database.Table<Note>().ToListAsync();
        }
       

        public Task<Note> GetNoteAsync(int id)
        {
            return _database.Table<Note>().Where(n => n.ID == id).FirstOrDefaultAsync();
        }
        public Task<List<Remainder>> GetRemaindersAsync()
        {
            return _database.Table<Remainder>().ToListAsync();
        }
        public Task<Remainder> GetRemainderAsync(int id)
        {
            return _database.Table<Remainder>().Where(n => n.ID == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveItem(object item)
        {
            var itemExist = item.GetType();
            if (itemExist == Remainder )
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

        public bool Chek(object item)
        {
            var itemExist = item.GetType();
            if (itemExist == Note || itemExist == Remainder)
            {
                return true;
            }
        }
    }
}
