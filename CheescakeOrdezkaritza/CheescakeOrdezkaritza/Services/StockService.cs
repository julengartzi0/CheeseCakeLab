using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using CheescakeOrdezkaritza.Models;

namespace CheescakeOrdezkaritza.Services
{
    public class StockService
    {
        private readonly SQLiteAsyncConnection _database;

        public StockService(SQLiteAsyncConnection database)
        {
            _database = database;
        }

        public Task<List<Stock>> EskuratuStockAsync()
        {
            return _database.Table<Stock>().ToListAsync();
        }

        public Task<int> GehituStockAsync(Stock stock)
        {
            return _database.InsertAsync(stock);
        }

        public Task<int> AktualizatuStockAsync(Stock stock)
        {
            return _database.UpdateAsync(stock);
        }

        public Task<int> EzabatuStockAsync(Stock stock)
        {
            return _database.DeleteAsync(stock);
        }

    }
}
