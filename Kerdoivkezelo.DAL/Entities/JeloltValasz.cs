using System;
using System.Collections.Generic;
using System.Text;

namespace Kerdoivkezelo.DAL.Entities
{
    public class JeloltValasz
    {
        public int Id { get; set; }
        public int KerdoivKitoltesekId { get; set; }
        public KerdoivKitoltes KerdoivKitoltese{ get; set; }
        public ICollection<ValaszOsszerendeles> ValaszOsszerendelesek { get; set; }
    }
}
