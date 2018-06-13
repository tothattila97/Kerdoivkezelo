using NetCoreAngular.Data.Kerdoiv;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kerdoivkezelo.DAL.Services
{
    public class KerdoivService
    {
        IList<Kerdoiv> mockKerdoivek = new List<Kerdoiv>();
        public void init()
        {
            Kerdoiv k1 = new Kerdoiv { Nev = "könnyű", IdoKorlat = 30, KitoltesSzam = 10, AtlagPontszam = 30, ElertPontszamSzumma = 170, MaxPontszam = 21 };
            Kerdoiv k2 = new Kerdoiv { Nev = "brutál", IdoKorlat = 60, KitoltesSzam = 4, AtlagPontszam = 45, ElertPontszamSzumma = 220, MaxPontszam = 33 };
            Kerdoiv k3 = new Kerdoiv { Nev = "nehéz", IdoKorlat = 24, KitoltesSzam = 47, AtlagPontszam = 14, ElertPontszamSzumma = 178, MaxPontszam = 18 };
            Kerdoiv k4 = new Kerdoiv { Nev = "közepes", IdoKorlat = 19, KitoltesSzam = 18, AtlagPontszam = 22, ElertPontszamSzumma = 95, MaxPontszam = 25 };
            mockKerdoivek.Add(k1);
            mockKerdoivek.Add(k2);
            mockKerdoivek.Add(k3);
            mockKerdoivek.Add(k4);
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
            foreach( var temp in mockKerdoivek)
            {
                if (temp.Nev.ToLower().Contains(querystr.ToLower()))
                {
                    result.Add(temp);
                }
            }
            return result;
        }

        public IList<Kerdoiv> GetSzurtKerdoivekByIdoIntervallum(int alsoIdoKorlat, int felsoIdokorlat)
        {
            init();
            IList<Kerdoiv> result = new List<Kerdoiv>();
            foreach(var temp in mockKerdoivek)
            {
                if(alsoIdoKorlat <= temp.IdoKorlat && felsoIdokorlat >= temp.IdoKorlat)
                {
                    result.Add(temp);
                }
            }
            return result;
        }
    }
}
