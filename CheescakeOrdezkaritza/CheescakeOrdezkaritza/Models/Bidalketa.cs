using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheescakeOrdezkaritza.Models
{
    [Table("bidalketa")]
    public class Bidalketa
    {
        [PrimaryKey, AutoIncrement]
        public int BidalketaKodea { get; set; }

        // Clave foránea
        public int EskaeraKodea { get; set; }
        public string BidalketaData { get; set; }
        public string Helburua { get; set; }
        public string Egoera { get; set; }
    }
}
