using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreAngular.Data.Kerdoiv
{
    public class KerdoivKitoltese
    {
        public string KerdoivNev { get; set; }

        public DateTime KitoltesKezdete { get; set; }

        public DateTime KitoltesVege { get; set; }

        public int Pontszam { get; set; }

        public int AktualisKerdes { get; set; }
    }
}
