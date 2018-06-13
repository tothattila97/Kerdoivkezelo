using NetCoreAngular.Data.Kerdoiv;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kerdoivkezelo.DAL.Entities
{
    public class ValaszOsszerendeles
    {
        public int Id { get; set; }
        public int ValaszElemId { get; set; }
        public ValaszElem ValaszElem { get; set; }

        public int KerdesId { get; set; }
        public Kerdes Kerdes { get; set; }
    }
}
