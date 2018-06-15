using Kerdoivkezelo.DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Kerdoivkezelo.DAL.Entities
{
    public class Kerdes
    {
        public int Id { get; set; }
        public virtual ICollection<KerdesOsszerendeles> KerdesOsszerendelesek{ get; set; }

        public virtual ICollection<ValaszOsszerendeles> Valaszlehetosegek { get; set; }
        public virtual ICollection<KerdoivKerdes>  KerdoivKerdesek { get; set; }
    }
}
