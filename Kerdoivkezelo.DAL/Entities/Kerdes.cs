using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreAngular.Data.Kerdoiv
{
    public class Kerdes
    {
        public ICollection<KerdesElem> KerdesElemek { get; set; }

        public ICollection<ValaszElem> ValaszElemek { get; set; }

        public ICollection<ValaszElem> HelyesValaszok { get; set; }

        public ICollection<ValaszElem> JeloltValaszok { get; set; }
    }
}
