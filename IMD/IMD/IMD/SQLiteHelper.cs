using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using System.Threading.Tasks;
using IMD.Models;
namespace IMD
{
    public class SQLiteHelper
    {
        private readonly SQLiteAsyncConnection db;
        public SQLiteHelper(string dbPath)
        {
            db = new SQLiteAsyncConnection(dbPath);
            db.CreateTableAsync<InformModel>();
        }
        public Task<int> CreateInform(InformModel inform)
        {
            return db.InsertAsync(inform);
        }
        public Task<List<InformModel>> ReadInform()
        {
            return db.Table<InformModel>().ToListAsync();
        }
        public Task<int> UpdateInform(InformModel inform)
        {
            return db.UpdateAsync(inform);
        }
        public Task<int> DeleteInform(InformModel inform)
        {
            return db.DeleteAsync(inform);
        }
    }
}

