using Kerdoivkezelo.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreAngular.Data.Kerdoiv
{
    public class KerdesElem
    {
        public string Szoveg { get; set; }
        public ICollection<KerdesOsszerendeles> KerdesOsszerendelesek { get; set; }
    }
}
