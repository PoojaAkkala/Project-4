using Calculator.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Calculator.Data
{
    public class HistoryDataBase
    {
        SQLiteAsyncConnection Database;
        
        async Task Init()
        {
            if (Database is not null)
                return;

            Database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
            var result = await Database.CreateTableAsync<CalcHistory>();
        }

        public async Task<List<CalcHistory>> GetItemsAsync()
        {
            await Init();
            return await Database.Table<CalcHistory>().ToListAsync();
        }

       

        public async Task<CalcHistory> GetItemAsync(int id)
        {
            await Init();
            return await Database.Table<CalcHistory>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public async Task<int> SaveItemAsync(CalcHistory item)
        {
            await Init();
             
           
            return await Database.InsertAsync(item);
            

        }

        public async Task<int> DeleteItemAsync(CalcHistory item)
        {
            await Init();
            return await Database.DeleteAsync(item);
        }
        public async Task<int> DeleteAllAsync()
        {
            await Init();
            return await Database.DeleteAllAsync<CalcHistory>();
        }
    }
}
