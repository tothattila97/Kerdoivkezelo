using Kerdoivkezelo.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kerdoivkezelo.DAL.Services
{
    public class KitoltesService
    {
        public KitoltesService(KerdoivKezeloDbContext context)
        {
            Context = context;
        }

        public KerdoivKezeloDbContext Context { get; }

        public List<Kerdoiv> GetKerdoivek()
        {
            return Context.Kerdoivek.ToList();
        }

        public List<KerdoivKitoltes> GetKitoltesek(int kerdoivId)
        {
            return Context.KerdoivKitoltesek.Where(k => (k.KerdoivId == kerdoivId)).ToList();
        }
    }
}
