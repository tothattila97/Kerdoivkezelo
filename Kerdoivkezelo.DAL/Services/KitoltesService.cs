using System;
using System.Collections.Generic;
using System.Text;
using NetCoreAngular.Data.Kerdoiv;

namespace Kerdoivkezelo.DAL.Services
{
    public class KitoltesService
    {
        private List<List<KerdoivKitoltese>> mockKitoltesek = new List<List<KerdoivKitoltese>>();

        private void init()
        {
            List<KerdoivKitoltese> l1 = new List<KerdoivKitoltese>();
            //fontos, hogy rendezett
            KerdoivKitoltese k1 = new KerdoivKitoltese { Pontszam = 4, Felhasznalo=new Felhasznalo {Name="user1" },KitoltesKezdete= new DateTimeOffset(),KitoltesVege=new DateTimeOffset() };
            KerdoivKitoltese k2 = new KerdoivKitoltese { Pontszam = 4, Felhasznalo = new Felhasznalo { Name = "user2" }, KitoltesKezdete = new DateTimeOffset(), KitoltesVege = new DateTimeOffset() };
            KerdoivKitoltese k3 = new KerdoivKitoltese { Pontszam = 2, Felhasznalo = new Felhasznalo { Name = "user3" }, KitoltesKezdete = new DateTimeOffset(), KitoltesVege = new DateTimeOffset() };
            KerdoivKitoltese k4 = new KerdoivKitoltese { Pontszam = 1, Felhasznalo = new Felhasznalo { Name = "user4" }, KitoltesKezdete = new DateTimeOffset(), KitoltesVege = new DateTimeOffset() };
            KerdoivKitoltese k5 = new KerdoivKitoltese { Pontszam = 0, Felhasznalo = new Felhasznalo { Name = "user5" }, KitoltesKezdete = new DateTimeOffset(), KitoltesVege = new DateTimeOffset() };
            l1.Add(k1);
            l1.Add(k2);
            l1.Add(k3);
            l1.Add(k4);
            l1.Add(k5);
            mockKitoltesek.Add(l1);

            List<KerdoivKitoltese> l2 = new List<KerdoivKitoltese>();
            mockKitoltesek.Add(l2);

            List<KerdoivKitoltese> l3 = new List<KerdoivKitoltese>();
            KerdoivKitoltese k6 = new KerdoivKitoltese { Pontszam = 14, Felhasznalo = new Felhasznalo { Name = "user6" }, KitoltesKezdete = new DateTimeOffset(), KitoltesVege = new DateTimeOffset() };
            KerdoivKitoltese k7 = new KerdoivKitoltese { Pontszam = 11, Felhasznalo = new Felhasznalo { Name = "user7" }, KitoltesKezdete = new DateTimeOffset(), KitoltesVege = new DateTimeOffset() };
            KerdoivKitoltese k8 = new KerdoivKitoltese { Pontszam = 10, Felhasznalo = new Felhasznalo { Name = "user8" }, KitoltesKezdete = new DateTimeOffset(), KitoltesVege = new DateTimeOffset() };
            l3.Add(k6);
            l3.Add(k7);
            l3.Add(k8);
            mockKitoltesek.Add(l3);
        }

        public List<List<KerdoivKitoltese>> GetMockKitoltesek()
        {
            init();
            return mockKitoltesek;
        }

        public Kerdoiv GetMockKerdoiv() {
            Kerdoiv ret = new Kerdoiv
            {
                Nev = "XY Kérdőív",
                MaxPontszam = 30,
            };
            return ret;
        }
    }
}
