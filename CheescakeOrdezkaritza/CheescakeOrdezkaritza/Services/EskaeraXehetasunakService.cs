using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheescakeOrdezkaritza.Models;

namespace CheescakeOrdezkaritza.Services
{
    public class EskaeraXehetasunakService
    {
        private readonly SQLiteAsyncConnection _database;

        public EskaeraXehetasunakService(SQLiteAsyncConnection database)
        {
            _database = database;
        }

        public Task<List<EskaeraXehetasuna>> EskuratuEskaeraXehetasunakAsync()
        {
            return _database.Table<EskaeraXehetasuna>().ToListAsync();
        }

        public Task<int> GehituEskaeraXehetasunaAsync(EskaeraXehetasuna eskaeraXehetasuna)
        {
            return _database.InsertAsync(eskaeraXehetasuna);
        }

        public async Task<int> AktualizatuEskaeraXehetasunaAsync(EskaeraXehetasuna eskaeraXehetasuna)
        {
            return await _database.UpdateAsync(eskaeraXehetasuna);
        }

        public Task<int> EzabatuEskaeraXehetasunaAsync(EskaeraXehetasuna eskaeraXehetasuna)
        {
            return _database.DeleteAsync(eskaeraXehetasuna);
        }


    }
}
