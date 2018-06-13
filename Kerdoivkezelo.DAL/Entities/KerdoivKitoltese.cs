using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreAngular.Data.Kerdoiv
{
    public class KerdoivKitoltese
    {
        public int Id { get; set; }
        public int KerdoivId { get; set; }
        public Kerdoiv Kerdoiv { get; set; }

        public int FelhasznaloId { get; set; }
        public Felhasznalo Felhasznalo { get; set; }

        public DateTimeOffset? KitoltesKezdete { get; set; }

        public DateTimeOffset? KitoltesVege { get; set; }

        public int? Pontszam { get; set; }

        public int? AktualisKerdes { get; set; }
    }
}
