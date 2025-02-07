using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheescakeOrdezkaritza.Models
{
    public class Produktua
    {
        [PrimaryKey, AutoIncrement]
        public int ProduktuaKodea { get; set; }

        public string Izena { get; set; }
        public double Prezioa { get; set; }
        public string Irudia { get; set; }

        [Ignore] // SQLite no la guardará en la BD
        public string Kantitatea { get; set; }
    }
}
