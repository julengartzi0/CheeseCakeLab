using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CheescakeOrdezkaritza.Models;
using System.Threading.Tasks;
using SQLite;

namespace CheescakeOrdezkaritza.Services
{
    public class EskaerakService
    {

        private readonly SQLiteAsyncConnection _database;

        public EskaerakService(SQLiteAsyncConnection database)
        {
            _database = database;
        }

        public Task<List<Eskaera>> EskuratuEskaerakAsync()
        {
            return _database.Table<Eskaera>().ToListAsync();
        }

        public Task<int> GehituEskaeraAsync(Eskaera eskaera)
        {
            return _database.InsertAsync(eskaera);
        }

        public async Task<int> AktualizatuEskaeraAsync(Eskaera eskaera)
        {
            return await _database.UpdateAsync(eskaera);
        }

        public Task<int> EzabatuEskaeraAsync(Eskaera eskaera)
        {
            return _database.DeleteAsync(eskaera);
        }
    }
}
