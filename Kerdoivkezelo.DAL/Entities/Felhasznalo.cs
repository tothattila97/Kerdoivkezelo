using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace Kerdoivkezelo.DAL.Entities
{
    public class Felhasznalo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ObservableCollection<KerdoivKitoltese> KerdoivKitoltesek { get; set; }
    }
}
