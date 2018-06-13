using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreAngular.Data.Kerdoiv
{
    public class Kerdes
    {
        public List<KerdesElem> KerdesElemek { get; set; }

        public List<ValaszElem> ValaszElemek { get; set; }

        public List<ValaszElem> HelyesValaszok { get; set; }

        public List<ValaszElem> JeloltValaszok { get; set; }
    }
}
