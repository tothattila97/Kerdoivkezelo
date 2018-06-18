using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kerdoivkezelo.DAL.Entities
{
    public class KerdoivKitoltes
    {
        public int Id { get; set; }
        public int KerdoivId { get; set; }
        public Kerdoiv Kerdoiv { get; set; }

        public int FelhasznaloId { get; set; }
        public User Felhasznalo { get; set; }

        public ICollection<JeloltValasz> JeloltValaszok { get; set; }

        public DateTimeOffset? KitoltesKezdete { get; set; }

        public DateTimeOffset? KitoltesVege { get; set; }

        public int? Pontszam { get; set; }

        public int? AktualisKerdes { get; set; }
    }
}
