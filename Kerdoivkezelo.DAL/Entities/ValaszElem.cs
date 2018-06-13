using Kerdoivkezelo.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreAngular.Data.Kerdoiv
{
    public class ValaszElem
    {
        public int Id { get; set; }
        public ICollection<ValaszOsszerendeles> ValaszOsszerendelesek { get; set; }
        public string Tartalom { get; set; }
    }
}
