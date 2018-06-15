using Kerdoivkezelo.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kerdoivkezelo.DAL.Seed
{
    public static class DbInitializer
    {
        public static void Initialize(KerdoivKezeloDbContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            InitKerdoivek(context);
            InitKerdoivKerdesekkelEsValaszokkal(context);
        }

        public static void InitKerdoivek(KerdoivKezeloDbContext context)
        {
            if (context.Kerdoivek.Any())
            {
                return;   // DB has been seeded
            }

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
            context.Kerdoivek.Add(k1);
            context.Kerdoivek.Add(k2);
            context.Kerdoivek.Add(k3);
            context.Kerdoivek.Add(k4);
            context.Kerdoivek.Add(k5);
            context.Kerdoivek.Add(k6);
            context.Kerdoivek.Add(k7);
            context.Kerdoivek.Add(k8);
            context.Kerdoivek.Add(k9);
            context.Kerdoivek.Add(k10);
            context.Kerdoivek.Add(k11);
            context.Kerdoivek.Add(k12);
            context.Kerdoivek.Add(k13);
            context.Kerdoivek.Add(k14);
            context.Kerdoivek.Add(k15);
            context.Kerdoivek.Add(k16);
            context.SaveChanges();
        }

        public static void InitKerdoivKerdesekkelEsValaszokkal(KerdoivKezeloDbContext context)
        {
            var kerdesElem = new KerdesElem() { Szoveg = "2+2=?" };
            context.KerdesElemek.Add(kerdesElem);

            var valaszElem1 = new ValaszElem() { Tartalom = "4" };
            var valaszElem2 = new ValaszElem() { Tartalom = "quickmaffs" };
            context.ValaszElemek.Add(valaszElem1);
            context.ValaszElemek.Add(valaszElem2);

            var kerdes = new Kerdes();
            context.Kerdesek.Add(kerdes);

            var kerdesOsszerendeles = new KerdesOsszerendeles() { KerdesId = kerdes.Id, KerdesElemId = kerdesElem.Id };
            context.KerdesOsszerendelesek.Add(kerdesOsszerendeles);

            var valaszOsszerendeles1 = new ValaszOsszerendeles() { Helyes = true, KerdesId = kerdes.Id, ValaszElemId = valaszElem1.Id };
            var valaszOsszerendeles2 = new ValaszOsszerendeles() { Helyes = false, KerdesId = kerdes.Id, ValaszElemId = valaszElem2.Id };
            context.ValaszOsszerendelesek.Add(valaszOsszerendeles1);
            context.ValaszOsszerendelesek.Add(valaszOsszerendeles2);

            var kerdoiv = new Kerdoiv { Nev = "TESZT-KÉRDÉSEKKEL", IdoKorlat = 30, KitoltesSzam = 0, AtlagPontszam = 0, ElertPontszamSzumma = 0, MaxPontszam = 0 };
            kerdoiv.Kerdesek.Add(kerdes);
            context.Kerdoivek.Add(kerdoiv);

            context.SaveChanges();
        }

        public static void InitKerdoivKerdesekkelEsValaszokkal2(KerdoivKezeloDbContext context)
        {
            if (context.Kerdoivek.Any(k => k.Nev == "TESZT-KÉRDÉSEKKEL"))
            {
                return;   // DB has been seeded
            }

            var kerdesElemek = new List<KerdesElem>();
            for (int i = 0; i < 1; i++)
            {
                kerdesElemek.Add(new KerdesElem() { Szoveg = $"{i}. Kérdés"});
                context.KerdesElemek.Add(kerdesElemek[i]);
            }

            var valaszElemek = new List<ValaszElem>();
            for (int i = 0; i < 2; i++)
            {
                valaszElemek.Add(new ValaszElem() { Tartalom = $"{i}. Válasz" });
            }

            var kerdesek = new List<Kerdes>();
            for (int i = 0; i < 1; i++)
            {
                kerdesek.Add(new Kerdes());
            }

            var kerdesOsszerendelesek = new List<KerdesOsszerendeles>();
            for (int i = 0; i < 1; i++)
            {
                kerdesOsszerendelesek.Add(new KerdesOsszerendeles() { Kerdes = kerdesek[i], KerdesElem = kerdesElemek[i] });
                context.KerdesOsszerendelesek.Add(kerdesOsszerendelesek[i]);
            }

            var valaszOsszerendelesek = new List<ValaszOsszerendeles>();
            for (int i = 0; i < 2; i++)
            {
                if (i % 10 == 0) valaszOsszerendelesek.Add(new ValaszOsszerendeles() { Helyes=true, Kerdes = kerdesek[i/4], ValaszElem = valaszElemek[i] });
                else valaszOsszerendelesek.Add(new ValaszOsszerendeles() { Helyes = false, Kerdes = kerdesek[i/4], ValaszElem = valaszElemek[i] });
                context.ValaszOsszerendelesek.Add(valaszOsszerendelesek[i]);
            }

            for (int i = 0; i < 1; i++)
            {
                kerdesek[i].KerdesOsszerendelesek.Add(kerdesOsszerendelesek[i]);
                for (int j = 0; j < 2; j++)
                {
                    kerdesek[i].Valaszlehetosegek.Add(valaszOsszerendelesek[i * 4 + j]);
                }
                context.Kerdesek.Add(kerdesek[i]);
            }

            for (int i = 0; i < 2; i++)
            {
                valaszElemek[i].ValaszOsszerendelesek.Add(valaszOsszerendelesek[i]);
                context.ValaszElemek.Add(valaszElemek[i]);
            }

            Kerdoiv kerdoiv = new Kerdoiv { Nev = "TESZT-KÉRDÉSEKKEL", IdoKorlat = 30, KitoltesSzam = 0, AtlagPontszam = 0, ElertPontszamSzumma = 0, MaxPontszam = 0, };
            kerdoiv.Kerdesek = kerdesek;
            //for (int i = 0; i < 10; i++)
            //{
            //    kerdoiv.Kerdesek.Add(kerdesek[i]);
            //}
            context.Kerdoivek.Add(kerdoiv);
            context.SaveChanges();
        }
    }
}
