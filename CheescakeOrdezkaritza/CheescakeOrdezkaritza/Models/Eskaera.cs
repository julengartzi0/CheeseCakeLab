using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheescakeOrdezkaritza.Models
{
    public class Eskaera
    {
        [PrimaryKey, AutoIncrement]
        public int EskaeraKodea { get; set; }

        // Usamos string para la fecha, 
        // pero puedes usar DateTime si lo manejas así en tu código
        public string EskaeraData { get; set; }

        // Claves foráneas
        public int KomertzialaKodea { get; set; }
        public int PartnerKodea { get; set; }
    } 
}
