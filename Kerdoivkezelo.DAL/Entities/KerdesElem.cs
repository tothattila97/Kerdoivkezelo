using Kerdoivkezelo.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kerdoivkezelo.DAL.Entities
{
    public class KerdesElem
    {
        public int Id { get; set; }
        public string Szoveg { get; set; }
        public ICollection<KerdesOsszerendeles> KerdesOsszerendelesek { get; set; }
    }
}
