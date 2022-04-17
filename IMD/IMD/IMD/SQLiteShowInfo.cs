using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using System.Threading.Tasks;
using IMD.Models;
namespace IMD
{
    public class SQLiteShowInfo
    {
        private readonly SQLiteAsyncConnection de;
        public SQLiteShowInfo(string dePath)
        {
            de = new SQLiteAsyncConnection(dePath);
            de.CreateTableAsync<ShowInfoModel>();
        }
        public Task<int> CreateShowInfo(ShowInfoModel showinfo)
        {
            return de.InsertAsync(showinfo);
        }
        public Task<List<ShowInfoModel>> ReadShowInfo()
        {
            return de.Table<ShowInfoModel>().ToListAsync();
        }
        public Task<int> UpdateShowInfo(ShowInfoModel showinfo)
        {
            return de.UpdateAsync(showinfo);
        }
        public Task<int> DeleteShowInfo(ShowInfoModel showinfo)
        {
            return de.DeleteAsync(showinfo);
        }
    }
}
