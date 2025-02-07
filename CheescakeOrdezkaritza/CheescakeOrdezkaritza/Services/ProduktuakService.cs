using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheescakeOrdezkaritza.Models;

namespace CheescakeOrdezkaritza.Services
{
    public class ProduktuakService
    {

        private readonly SQLiteAsyncConnection _database;

        public ProduktuakService(SQLiteAsyncConnection database)
        {
            _database = database;
        }

        public Task<List<Produktua>> EskuratuProduktuakAsync()
        {
            return _database.Table<Produktua>().ToListAsync();
        }

        public Task<int> GehituProduktuaAsync(Produktua produktua)
        {
            return _database.InsertAsync(produktua);
        }

        public Task<int> AktualizatuProduktuaAsync(Produktua produktua)
        {
            return _database.UpdateAsync(produktua);
        }

        public Task<int> EzabatuProduktuaAsync(Produktua produktua)
        {
            return _database.DeleteAsync(produktua);
        }

    }
}
