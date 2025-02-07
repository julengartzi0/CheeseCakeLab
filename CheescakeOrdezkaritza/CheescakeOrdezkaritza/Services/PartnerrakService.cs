using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using CheescakeOrdezkaritza.Models;

namespace CheescakeOrdezkaritza.Services
{
    public class PartnerrakService
    {

        private readonly SQLiteAsyncConnection _database;

        public PartnerrakService(SQLiteAsyncConnection database)
        {
            _database = database;
        }

        public Task<List<Partner>> EskuratuPartnerrakAsync()
        {
            return _database.Table<Partner>().ToListAsync();
        }

        public Task<int> GehituPartnerrakAsync(Partner partner)
        {
            return _database.InsertAsync(partner);
        }

        public Task<int> AktualizatuPartnerrakAsync(Partner partner)
        {
            return _database.UpdateAsync(partner);
        }

        public Task<int> EzabatuPartnerrakAsync(Partner partner)
        {
            return _database.DeleteAsync(partner);
        }

    }
}
