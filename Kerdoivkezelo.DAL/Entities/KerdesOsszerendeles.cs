using Kerdoivkezelo.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kerdoivkezelo.DAL.Entities
{
    public class KerdesOsszerendeles
    {
        public int Id { get; set; }
        public int KerdesId { get; set; }
        public Kerdes Kerdes{ get; set; }

        public int KerdesElemId { get; set; }
        public KerdesElem KerdesElem { get; set; }
    }
}
