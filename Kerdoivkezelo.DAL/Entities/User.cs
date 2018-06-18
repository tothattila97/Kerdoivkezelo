using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace Kerdoivkezelo.DAL.Entities
{
    public class User : IdentityUser
    {
        public string Name { get; set; }
        public string Age { get; set;}
        public ObservableCollection<KerdoivKitoltes> KerdoivKitoltesek { get; set; }
    }
}
