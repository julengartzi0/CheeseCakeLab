using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheescakeOrdezkaritza.Models
{
    public class Komertziala
    {
        [PrimaryKey, AutoIncrement]
        public int KomertzialaKodea { get; set; }

        public string Izena { get; set; }
        public string Abizena { get; set; }
        public string Telefonoa { get; set; }
        public string Email { get; set; }

        // Clave foránea que referencia a Ordezkaritza(OrdezkaritzaKodea)
        public int OrdezkaritzaKodea { get; set; }
    }
}
