using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreAngular.Data.Kerdoiv
{
    public class Felhasznalo
    {
        public string Name { get; set; }
        public ObservableCollection<KerdoivKitoltese> KerdoivKitoltesek { get; set; }
    }
}
