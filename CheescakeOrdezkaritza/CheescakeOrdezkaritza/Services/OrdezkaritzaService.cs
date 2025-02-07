using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
using CheescakeOrdezkaritza.Models;

namespace CheescakeOrdezkaritza.Services
{
    /// <summary>
    /// OrdezkaritzaService klasea datu baseko "Ordezkaritza" taularen kudeaketa egiteko erabiltzen da.
    /// </summary>
    public class OrdezkaritzaService
    {
        private readonly SQLiteAsyncConnection _database;

        /// <summary>
        /// Eraikitzailea: SQLiteAsyncConnection objektua ezartzen du.
        /// </summary>
        /// <param name="database">Datu basearekin konektatzeko objektua.</param>
        public OrdezkaritzaService(SQLiteAsyncConnection database)
        {
            _database = database;
        }

        /// <summary>
        /// Ordezkaritza guztiak lortzen ditu "Ordezkaritza" taulatik.
        /// </summary>
        /// <returns>Ordezkaritzen zerrenda asinkronikoki itzultzen du.</returns>
        public Task<List<Ordezkaritza>> EskuratuOrdezkaritzakAsync()
        {
            return _database.Table<Ordezkaritza>().ToListAsync();
        }

        /// <summary>
        /// Ordezkaritza berria gehitzen du "Ordezkaritza" taulan.
        /// </summary>
        /// <param name="ordezkaritza">Gehitu nahi den ordezkaritzaren objektua.</param>
        /// <returns>Txertaketaren emaitza itzultzen du.</returns>
        public Task<int> GehituOrdezkaritzaAsync(Ordezkaritza ordezkaritza)
        {
            return _database.InsertAsync(ordezkaritza);
        }

        /// <summary>
        /// Ordezkaritzaren datuak eguneratzen ditu "Ordezkaritza" taulan.
        /// </summary>
        /// <param name="ordezkaritza">Eguneratu nahi den ordezkaritzaren objektua.</param>
        /// <returns>Eguneratzearen emaitza itzultzen du.</returns>
        public Task<int> AktualizatuOrdezkaritzaAsync(Ordezkaritza ordezkaritza)
        {
            return _database.UpdateAsync(ordezkaritza);
        }

        /// <summary>
        /// Ordezkaritza bat ezabatzen du "Ordezkaritza" taulatik.
        /// </summary>
        /// <param name="ordezkaritza">Ezabatu nahi den ordezkaritzaren objektua.</param>
        /// <returns>Ezabaketaren emaitza itzultzen du.</returns>
        public Task<int> EzabatuOrdezkaritzaAsync(Ordezkaritza ordezkaritza)
        {
            return _database.DeleteAsync(ordezkaritza);
        }
    }
}
