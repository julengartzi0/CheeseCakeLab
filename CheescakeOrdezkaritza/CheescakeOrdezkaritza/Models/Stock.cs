using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheescakeOrdezkaritza.Models
{
    [Table("stock")]
    public class Stock
    {
        [PrimaryKey, AutoIncrement]
        public int StockKodea { get; set; }

        // Claves foráneas
        public int ProduktuaKodea { get; set; }
        public int OrdezkaritzaKodea { get; set; }

        public int Kantitatea { get; set; }
    }
}
