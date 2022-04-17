using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using System.Threading.Tasks;
using IMD.Models;
namespace IMD
{
    public class SQLiteHelperFB
    {
        private readonly SQLiteAsyncConnection dc;
        public SQLiteHelperFB(string dbPath)
        {
            dc = new SQLiteAsyncConnection(dbPath);
            dc.CreateTableAsync<FeedbackModel>();
        }
        public Task<int> CreateFeedback(FeedbackModel feedback)
        {
            return dc.InsertAsync(feedback);
        }
        public Task<List<FeedbackModel>> ReadFeedback()
        {
            return dc.Table<FeedbackModel>().ToListAsync();
        }
        public Task<int> UpdateFeedback(FeedbackModel feedback)
        {
            return dc.UpdateAsync(feedback);
        }
        public Task<int> DeleteFeedback(FeedbackModel feedback)
        {
            return dc.DeleteAsync(feedback);
        }
        public Task<List<FeedbackModel>> Search(string search)
        {
            return dc.Table<FeedbackModel>().Where(p => p.TitleFB.StartsWith(search)).ToListAsync();
        }
    }
}