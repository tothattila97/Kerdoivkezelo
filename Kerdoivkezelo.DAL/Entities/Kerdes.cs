using Kerdoivkezelo.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreAngular.Data.Kerdoiv
{
    public class Kerdes
    {
        public int Id { get; set; }
        public ICollection<KerdesOsszerendeles> GetKerdesOsszerendelesek{ get; set; }

        public ICollection<ValaszOsszerendeles> Valaszlehetosegek { get; set; }

        public ICollection<ValaszOsszerendeles> HelyesValaszok { get; set; }

        public ICollection<ValaszOsszerendeles> JeloltValaszok { get; set; }
    }
}
