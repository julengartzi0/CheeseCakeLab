using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheescakeOrdezkaritza.Models
{
    public class EskaeraXehetasuna
    {
        [PrimaryKey, AutoIncrement]
        public int XehetasunKodea { get; set; }

        // Claves foráneas
        public int EskaeraKodea { get; set; }
        public int ProduktuaKodea { get; set; }

        public int Kantitatea { get; set; }
        public double Prezioa { get; set; }
    }
}
