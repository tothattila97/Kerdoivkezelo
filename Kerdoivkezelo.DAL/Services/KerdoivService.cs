using NetCoreAngular.Data.Kerdoiv;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kerdoivkezelo.DAL.Services
{
    public class KerdoivService
    {
        private static int oldalMeret = 5;

        IList<Kerdoiv> mockKerdoivek = new List<Kerdoiv>();
        public void init()
        {
            Kerdoiv k1 = new Kerdoiv { Nev = "könnyű", IdoKorlat = 30, KitoltesSzam = 10, AtlagPontszam = 30, ElertPontszamSzumma = 170, MaxPontszam = 21 };
            Kerdoiv k2 = new Kerdoiv { Nev = "brutál", IdoKorlat = 60, KitoltesSzam = 4, AtlagPontszam = 45, ElertPontszamSzumma = 220, MaxPontszam = 33 };
            Kerdoiv k3 = new Kerdoiv { Nev = "nehéz", IdoKorlat = 24, KitoltesSzam = 47, AtlagPontszam = 14, ElertPontszamSzumma = 178, MaxPontszam = 18 };
            Kerdoiv k4 = new Kerdoiv { Nev = "közepes", IdoKorlat = 19, KitoltesSzam = 18, AtlagPontszam = 22, ElertPontszamSzumma = 95, MaxPontszam = 25 };
            Kerdoiv k5 = new Kerdoiv { Nev = "test1", IdoKorlat = 30, KitoltesSzam = 10, AtlagPontszam = 30, ElertPontszamSzumma = 170, MaxPontszam = 21 };
            Kerdoiv k6 = new Kerdoiv { Nev = "test2", IdoKorlat = 60, KitoltesSzam = 4, AtlagPontszam = 45, ElertPontszamSzumma = 220, MaxPontszam = 33 };
            Kerdoiv k7 = new Kerdoiv { Nev = "test3", IdoKorlat = 24, KitoltesSzam = 47, AtlagPontszam = 14, ElertPontszamSzumma = 178, MaxPontszam = 18 };
            Kerdoiv k8 = new Kerdoiv { Nev = "test4", IdoKorlat = 19, KitoltesSzam = 18, AtlagPontszam = 22, ElertPontszamSzumma = 95, MaxPontszam = 25 };
            Kerdoiv k9 = new Kerdoiv { Nev = "test5", IdoKorlat = 30, KitoltesSzam = 10, AtlagPontszam = 30, ElertPontszamSzumma = 170, MaxPontszam = 21 };
            Kerdoiv k10 = new Kerdoiv { Nev = "test6", IdoKorlat = 60, KitoltesSzam = 4, AtlagPontszam = 45, ElertPontszamSzumma = 220, MaxPontszam = 33 };
            Kerdoiv k11 = new Kerdoiv { Nev = "test7", IdoKorlat = 24, KitoltesSzam = 47, AtlagPontszam = 14, ElertPontszamSzumma = 178, MaxPontszam = 18 };
            Kerdoiv k12 = new Kerdoiv { Nev = "test8", IdoKorlat = 19, KitoltesSzam = 18, AtlagPontszam = 22, ElertPontszamSzumma = 95, MaxPontszam = 25 };
            Kerdoiv k16 = new Kerdoiv { Nev = "test9", IdoKorlat = 30, KitoltesSzam = 10, AtlagPontszam = 30, ElertPontszamSzumma = 170, MaxPontszam = 21 };
            Kerdoiv k13 = new Kerdoiv { Nev = "test10", IdoKorlat = 60, KitoltesSzam = 4, AtlagPontszam = 45, ElertPontszamSzumma = 220, MaxPontszam = 33 };
            Kerdoiv k14 = new Kerdoiv { Nev = "test11", IdoKorlat = 24, KitoltesSzam = 47, AtlagPontszam = 14, ElertPontszamSzumma = 178, MaxPontszam = 18 };
            Kerdoiv k15 = new Kerdoiv { Nev = "test12", IdoKorlat = 19, KitoltesSzam = 18, AtlagPontszam = 22, ElertPontszamSzumma = 95, MaxPontszam = 25 };
            mockKerdoivek.Add(k1);   
            mockKerdoivek.Add(k2);
            mockKerdoivek.Add(k3);
            mockKerdoivek.Add(k4);
            mockKerdoivek.Add(k5);
            mockKerdoivek.Add(k6);
            mockKerdoivek.Add(k7);
            mockKerdoivek.Add(k8);
            mockKerdoivek.Add(k9);
            mockKerdoivek.Add(k10);
            mockKerdoivek.Add(k11);
            mockKerdoivek.Add(k12);
            mockKerdoivek.Add(k13);
            mockKerdoivek.Add(k14);
            mockKerdoivek.Add(k15);
            mockKerdoivek.Add(k16);
        }

        public IList<Kerdoiv> GetMockKerdoivek()
        {
            init();
            return mockKerdoivek;
        }

        public IList<Kerdoiv> GetSzurtKerdoivekByMegnevezes(string querystr)
        {
            init();
            IList<Kerdoiv> result = new List<Kerdoiv>();
            foreach( var tempKerdoiv in mockKerdoivek)
            {
                if (tempKerdoiv.Nev.ToLower().Contains(querystr.ToLower()))
                {
                    result.Add(tempKerdoiv);
                }
            }
            return result;
        }

        public IList<Kerdoiv> GetSzurtKerdoivekByIdoIntervallum(int alsoIdoKorlat, int felsoIdokorlat)
        {
            init();
            IList<Kerdoiv> result = new List<Kerdoiv>();
            foreach(var tempKerdoiv in mockKerdoivek)
            {
                if(alsoIdoKorlat <= tempKerdoiv.IdoKorlat && felsoIdokorlat >= tempKerdoiv.IdoKorlat)
                {
                    result.Add(tempKerdoiv);
                }
            }
            return result;
        }

        public IList<Kerdoiv> GetKerdoivekAdottOldalon(int oldalszam)
        {
            init();
            return mockKerdoivek.Skip(oldalszam * oldalMeret).Take(oldalMeret).ToList();
        }

        public int GetMaxOldalszam()
        {
            init();
            return (mockKerdoivek.Count / oldalMeret) + 1;
        }
    }
}
