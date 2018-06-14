using System;
using System.Collections.Generic;
using System.Text;
using NetCoreAngular.Data.Kerdoiv;

namespace Kerdoivkezelo.DAL.Services
{
    public class KitoltesService
    {

        private Kerdoiv CreateKerdoiv(string nev, int maxPont) {
            return new Kerdoiv
            {
                Nev = nev,
                MaxPontszam = maxPont
            };
        }

        public List<Kerdoiv> GetKerdoivek() {
            List<Kerdoiv> ret = new List<Kerdoiv>();
            ret.Add(CreateKerdoiv("Kérdőív 1", 30));
            ret.Add(CreateKerdoiv("Kérdőív 2", 100));
            return ret;
        }

        private KerdoivKitoltese CreateKitoltes(int pont, string felhasznalo) {
            return new KerdoivKitoltese {
                Pontszam = pont,
                Felhasznalo = new Felhasznalo { Name = felhasznalo },
                KitoltesKezdete = new DateTimeOffset(),
                KitoltesVege = new DateTimeOffset() };
        }

        public List<KerdoivKitoltese> GetKitoltesek(int ketdoivId) {
            List<KerdoivKitoltese> ret = new List<KerdoivKitoltese>();
            ret.Add(CreateKitoltes(16, "user1"));
            ret.Add(CreateKitoltes(5, "user2"));
            ret.Add(CreateKitoltes(29, "user3"));
            ret.Add(CreateKitoltes(16, "user4"));
            ret.Add(CreateKitoltes(0, "user5"));
            ret.Add(CreateKitoltes(1, "user6"));
            ret.Add(CreateKitoltes(11, "user7"));
            ret.Add(CreateKitoltes(7, "user8"));
            ret.Add(CreateKitoltes(30, "user9"));
            ret.Add(CreateKitoltes(4, "user10"));
            ret.Add(CreateKitoltes(23, "user11"));
            ret.Add(CreateKitoltes(27, "user12"));
            ret.Add(CreateKitoltes(18, "user13"));
            ret.Add(CreateKitoltes(11, "user14"));
            ret.Add(CreateKitoltes(12, "user15"));
            return ret;
        }
    }
}
