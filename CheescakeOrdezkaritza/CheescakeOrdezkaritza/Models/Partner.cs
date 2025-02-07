using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheescakeOrdezkaritza.Models
{
    [Table("partner")]
    public class Partner
    {
        [PrimaryKey, AutoIncrement]
        public int PartnerKodea { get; set; }

        public string Izena { get; set; }
        public string Helbidea { get; set; }
        public string Telefonoa { get; set; }
        public string Email { get; set; }

        // Clave foránea que referencia a Ordezkaritza(OrdezkaritzaKodea)
        public int OrdezkaritzaKodea { get; set; }

        [Ignore] // SQLite no la guardará en la BD
        public string OrdezkaritzaIzena { get; set; }
    }
}
