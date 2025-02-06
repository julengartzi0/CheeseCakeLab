using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheescakeOrdezkaritza.Models
{
    [Table("bisita")]
    public class Bisita
    {
        [PrimaryKey, AutoIncrement]
        public int BisitaKodea { get; set; }

        // Claves foráneas
        public int KomertzialaKodea { get; set; }
        public int PartnerKodea { get; set; }

        public string BisitaData { get; set; }
        public string Kokapena { get; set; }
    }
}
