using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheescakeOrdezkaritza.Models
{
    public class Ordezkaritza
    {
        [PrimaryKey, AutoIncrement]
        public int OrdezkaritzaKodea { get; set; }

        public string Izena { get; set; }

        public string Helbidea { get; set; }

        public string Telefonoa { get; set; }

        public string Email { get; set; }

        public string MapaURL { get; set; }
    }

}
