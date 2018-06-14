using System;
using System.Collections.Generic;
using System.Text;

namespace Kerdoivkezelo.DAL.Entities
{
    public class KerdoivKerdes
    {
        public int KerdesId { get; set; }
        public Kerdes Kerdes { get; set; }
        public int KerdoivId { get; set; }
        public Kerdoiv Kerdoiv { get; set; }
    }
}
